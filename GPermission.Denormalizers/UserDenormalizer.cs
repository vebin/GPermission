using ENode.Infrastructure;
using GPermission.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommon.IO;
using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;

namespace GPermission.Denormalizers
{
    /// <summary>用户持久化
    /// </summary>
    public class UserDenormalizer : AbstractDenormalizer
        , IMessageHandler<UserCreated>                                    //创建用户
        , IMessageHandler<UserRoleAdded>                                  //添加用户角色
        , IMessageHandler<UserRoleRemoved>                                //删除用户角色   
        , IMessageHandler<UserRoleReset>                                  //重置用户角色                 
        , IMessageHandler<UserChanged>                                    //删除用户     
    {

        /// <summary>创建用户
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(UserCreated evnt)
        {
            return TryInsertRecordAsync(connection =>
            {
                var info = evnt.Info;
                return connection.InsertAsync(new
                {
                    UserId = evnt.AggregateRootId,
                    AppSystemId = info.AppSystemId,
                    Code = info.Code,
                    UserName = info.UserName,
                    UseFlag = (int)UseFlag.Useable,
                    ReMark = info.ReMark,
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, ConfigSettings.UserTable);
            });
        }

        /// <summary>添加用户角色
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(UserRoleAdded evnt)
        {
            return TryTransactionAsync(async (connection, transaction) =>
            {
                var effectedRows = await connection.UpdateAsync(new
                {
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    UserId=evnt.AggregateRootId,
                    Version=evnt.Version-1,
                }, ConfigSettings.UserTable, transaction);

                if (effectedRows == 1)
                {
                    var tasks = new List<Task>();
                    foreach (var roleId in evnt.RoleIds)
                    {
                        tasks.Add(connection.InsertAsync(new
                        {
                            UserId = evnt.AggregateRootId,
                            RoleId = roleId
                        }, ConfigSettings.UserRoleTable, transaction));
                    }
                    await Task.WhenAll(tasks);
                }
            });
        }

        /// <summary>移除用户角色
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(UserRoleRemoved evnt)
        {
            return TryTransactionAsync(async (connection, transaction) =>
            {
                var effectedRows = await connection.UpdateAsync(new
                {
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    UserId = evnt.AggregateRootId,
                    Version = evnt.Version - 1,
                }, ConfigSettings.UserTable, transaction);

                if (effectedRows == 1)
                {
                    await connection.DeleteAsync(new
                    {
                        UserId=evnt.AggregateRootId,
                        RoleId=evnt.RoleId
                    }, ConfigSettings.UserRoleTable, transaction);
                }
            });
        }

        /// <summary>重置用户角色
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(UserRoleReset evnt)
        {
            return TryTransactionAsync(async (connection, transaction) =>
            {
                var effectedRows = await connection.UpdateAsync(new
                {
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    UserId = evnt.AggregateRootId,
                    Version = evnt.Version - 1,
                }, ConfigSettings.UserTable, transaction);

                if (effectedRows == 1)
                {
                    var tasks = new List<Task>();
                    tasks.Add(connection.DeleteAsync(new
                    {
                        UserId = evnt.AggregateRootId,
                    }, ConfigSettings.UserRoleTable, transaction));
                    //增加
                    foreach (var roleId in evnt.RoleIds)
                    {
                        tasks.Add(connection.InsertAsync(new
                        {
                            UserId = evnt.AggregateRootId,
                            RoleId=roleId
                        }, ConfigSettings.UserRoleTable, transaction));
                    }
                    await Task.WhenAll(tasks);
                }
            });
        }

        /// <summary>删除用户
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(UserChanged evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    UseFlag=evnt.UseFlag,
                    Version=evnt.Version,
                    EventSequence=evnt.Sequence
                }, new
                {
                    UserId=evnt.AggregateRootId,
                    Version=evnt.Version-1
                }, ConfigSettings.UserTable);
            });
        }
    }
}
