using ENode.Infrastructure;
using GPermission.Domain.Roles;
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
    /// <summary>角色持久化
    /// </summary>
    public class RoleDenormalizer : AbstractDenormalizer
        , IMessageHandler<RoleCreated>                                               //创建角色
        , IMessageHandler<RoleChanged>                                               //删除角色
        , IMessageHandler<RoleModulePermissionAttached>                              //添加角色模块权限
        , IMessageHandler<RoleModulePermissionDetached>                              //删除角色模块权限
        , IMessageHandler<RoleModulePermissionUpdated>                               //更新角色模块权限
    {

        /// <summary>创建角色
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(RoleCreated evnt)
        {
            return TryInsertRecordAsync(connection =>
            {
                var info = evnt.Info;
                return connection.InsertAsync(new
                {
                    RoleId=evnt.AggregateRootId,
                    AppSystemId=info.AppSystemId,
                    Code=info.Code,
                    Name=info.Name,
                    RoleType=info.RoleType,
                    IsEnabled=evnt.IsEnabled,
                    UseFlag=(int)UseFlag.Useable,
                    ReMark=info.ReMark,
                    Version=evnt.Version,
                    EventSequence=evnt.Sequence
                }, ConfigSettings.RoleTable);
            });
        }

        /// <summary>删除角色
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(RoleChanged evnt)
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
                    RoleId=evnt.AggregateRootId,
                    Version=evnt.Version-1
                }, ConfigSettings.RoleTable);
            });
        }

        /// <summary>添加角色模块权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(RoleModulePermissionAttached evnt)
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
                }, ConfigSettings.RoleTable, transaction);

                if (effectedRows == 1)
                {
                    var tasks = new List<Task>();
                    foreach (var modulePermissionId in evnt.ModulePermissionIds)
                    {
                        tasks.Add(connection.InsertAsync(new
                        {
                            RoleId = evnt.AggregateRootId,
                            ModulePermissionId = modulePermissionId
                        }, ConfigSettings.RoleModulePermissionTable, transaction));
                    }
                    await Task.WhenAll(tasks);
                }
            });
        }

        /// <summary>删除角色模块权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(RoleModulePermissionDetached evnt)
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
                }, ConfigSettings.RoleTable, transaction);

                if (effectedRows == 1)
                {
                    await connection.DeleteAsync(new
                    {
                        RoleId = evnt.AggregateRootId,
                        ModulePermissionId = evnt.ModulePermissionId
                    }, ConfigSettings.RoleModulePermissionTable, transaction);
                }
            });
        }

        /// <summary>更新角色模块权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(RoleModulePermissionUpdated evnt)
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
                }, ConfigSettings.RoleTable, transaction);

                if (effectedRows == 1)
                {
                    var tasks = new List<Task>();
                    //删除关联
                    tasks.Add(connection.DeleteAsync(new
                    {
                        RoleId=evnt.AggregateRootId
                    }, ConfigSettings.RoleModulePermissionTable, transaction));


                    foreach (var modulePermissionId in evnt.ModulePermissionIds)
                    {
                        tasks.Add(connection.InsertAsync(new
                        {
                            RoleId = evnt.AggregateRootId,
                            ModulePermissionId = modulePermissionId
                        }, ConfigSettings.RoleModulePermissionTable, transaction));
                    }
                    await Task.WhenAll(tasks);
               
                }
            });
        }
    }
}
