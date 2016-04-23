using ENode.Infrastructure;
using GPermission.Domain.Accounts;
using System.Collections.Generic;
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
        , IMessageHandler<AccountCreated> //创建账号
        , IMessageHandler<AccountChanged> //删除账号
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
                    AccountId = evnt.AggregateRootId,
                    AccountName = info.AccountName,
                    AccountPassword = info.AccountPassword,
                    AccountType = info.AccountType,
                    CreateTime = info.CreateTime,
                    Status = AccountStatus.Normal.ToString(),
                    UseFlag = (int) UseFlag.Useable,
                    ReMark = info.ReMark,
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, ConfigSettings.AccountTable);
            });
        }

        /// <summary>删除账号
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(AccountChanged evnt)
        {
            return TryUpdateRecordAsync(connection => connection.UpdateAsync(new
            {
                UseFlag = evnt.UseFlag,
                Version = evnt.Version,
                EventSequence = evnt.Sequence
            }, new
            {
                AccountId = evnt.AggregateRootId,
                Version = evnt.Version - 1
            }, ConfigSettings.AccountTable));
        }
    }
}
