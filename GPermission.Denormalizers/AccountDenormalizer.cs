using ENode.Infrastructure;
using GPermission.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommon.IO;
using GPermission.Common;
using ECommon.Dapper;
using GPermission.Common.Enums;

namespace GPermission.Denormalizers
{
    /// <summary>账号持久化
    /// </summary>
    public class AccountDenormalizer : AbstractDenormalizer
        , IMessageHandler<AccountCreated>                                            //创建账号
        , IMessageHandler<AccountChanged>                                            //删除账号
        , IMessageHandler<AppSystemAttached>                                            //添加账号下应用系统
        , IMessageHandler<AppSystemDetached>                                          //移除账号下应用系统
        , IMessageHandler<AppSystemReset>                                            //重置账号下应用系统
    {

        /// <summary>创建账号
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(AccountCreated evnt)
        {
            return TryInsertRecordAsync(connection =>
            {
                var info = evnt.Info;
                return connection.InsertAsync(new
                {
                    AccountId=evnt.AggregateRootId,
                    AccountName=info.AccountName,
                    AccountPassword=info.AccountPassword,
                    AccountType=info.AccountType,
                    CreateTime=info.CreateTime,
                    Status=AccountStatus.Normal.ToString(),
                    UseFlag=(int)UseFlag.Useable,
                    ReMark=info.ReMark,
                    Version=evnt.Version,
                    EventSequence=evnt.Sequence
                }, ConfigSettings.AccountTable);
            });
        }

        /// <summary>删除账号
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(AccountChanged evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    UseFlag = evnt.UseFlag,
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    AccountId=evnt.AggregateRootId,
                    Version=evnt.Version-1
                }, ConfigSettings.AccountTable);
            });
        }

        /// <summary>添加应用系统
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(AppSystemAttached evnt)
        {
            return TryTransactionAsync(async (connection, transaction) =>
            {
                var effectedRows = await connection.UpdateAsync(new
                {
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    AccountId = evnt.AggregateRootId,
                    Version = evnt.Version - 1,
                }, ConfigSettings.AccountTable, transaction);

                if (effectedRows == 1)
                {
                    var tasks = new List<Task>();
                    foreach (var appSystemId in evnt.AppSystemIds)
                    {
                        tasks.Add(connection.InsertAsync(new
                        {
                            AccountId = evnt.AggregateRootId,
                            AppSystemId = appSystemId
                        }, ConfigSettings.AccountAppSystemTable, transaction));
                    }
                    await Task.WhenAll(tasks);
                }
            });
        }

        /// <summary>移除账号下应用系统
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(AppSystemDetached evnt)
        {
            return TryTransactionAsync(async (connection, transaction) =>
            {
                var effectedRows = await connection.UpdateAsync(new
                {
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    AccountId = evnt.AggregateRootId,
                    Version = evnt.Version - 1,
                }, ConfigSettings.AccountTable, transaction);

                if (effectedRows == 1)
                {
                    await connection.DeleteAsync(new
                    {
                        AccountId=evnt.AggregateRootId,
                        AppSystemId=evnt.AppSystemId
                    }, ConfigSettings.AccountAppSystemTable, transaction);
                }
            });
        }

        /// <summary>重置账号下应用系统
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(AppSystemReset evnt)
        {
            return TryTransactionAsync(async (connection, transaction) =>
            {
                var effectedRows = await connection.UpdateAsync(new
                {
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    AccountId = evnt.AggregateRootId,
                    Version = evnt.Version - 1,
                }, ConfigSettings.AccountTable, transaction);

                if (effectedRows == 1)
                {
                    var tasks = new List<Task>();
                    //删除现有关联
                    tasks.Add(connection.DeleteAsync(new
                    {
                        AccountId=evnt.AggregateRootId
                    }, ConfigSettings.AccountAppSystemTable, transaction));

                    foreach (var appSystemId in evnt.AppSystemIds)
                    {
                        tasks.Add(connection.InsertAsync(new
                        {
                            AccountId=evnt.AggregateRootId,
                            AppSystemId=appSystemId
                        }, ConfigSettings.AccountAppSystemTable, transaction));
                    }
                    await Task.WhenAll(tasks);
                }
            });
        }
    }
}
