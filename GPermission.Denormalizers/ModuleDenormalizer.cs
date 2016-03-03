using ENode.Infrastructure;
using GPermission.Domain.Modules;
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
    /// <summary>模块持久化
    /// </summary>
    public class ModuleDenormalizer : AbstractDenormalizer
        , IMessageHandler<ModuleCreated>                                                //创建模块
        , IMessageHandler<ModuleUpdated>                                                //更新模块
        , IMessageHandler<ModuleChanged>                                                //删除模块
        , IMessageHandler<ModuleVisibled>                                               //设置模块可见
        , IMessageHandler<ModuleInVisibled>                                             //设置模块不可见
        , IMessageHandler<ModuleLeafSetted>                                             //设置模块是否叶子节点
        , IMessageHandler<ModuleLocked>                                                 //锁定模块
        , IMessageHandler<ModuleUnLock>                                                 //解锁模块
        , IMessageHandler<ModulePermissionAttached>                                     //添加模块权限
        , IMessageHandler<ModulePermissionUpdated>                                      //更新模块权限
        , IMessageHandler<ModulePermissionDetached>                                     //删除模块权限
    {

        /// <summary>创建模块
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModuleCreated evnt)
        {
            return TryInsertRecordAsync(connection =>
            {
                var info = evnt.Info;
                return connection.InsertAsync(new
                {
                    ModuleId=evnt.AggregateRootId,
                    AppSystemId=info.AppSystemId,
                    Code=info.Code,
                    Name=info.Name,
                    ModuleType=info.ModuleType,
                    ParentModule=info.ParentModule,
                    LinkUrl=info.LinkUrl,
                    AssemblyName=info.AssemblyName,
                    FullName=info.FullName,
                    IsLeaf=(int)BoolEnum.True,
                    Sort = info.Sort,
                    VerifyType =evnt.VerifyType,
                    IsVisible=evnt.IsVisible,
                    Status=ModuleStatus.Normal.ToString(),
                    UseFlag =(int)UseFlag.Useable,
                    ReMark = info.ReMark,
                    Version = evnt.Version,
                    EventSequence=evnt.Sequence
                }, ConfigSettings.ModuleTable);
            });
        }

        /// <summary>更新模块
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModuleUpdated evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                var info = evnt.Info;
                return connection.UpdateAsync(new
                {
                    Name=info.Name,
                    ModuleType=info.ModuleType,
                    ParentModule=info.ParentModule,
                    LinkUrl=info.LinkUrl,
                    AssemblyName=info.AssemblyName,
                    FullName=info.FullName,
                    Sort=info.Sort,
                    ReMark=info.ReMark,
                    Version=evnt.Version,
                    EventSequence=evnt.Sequence

                }, new
                {
                    ModuleId=evnt.AggregateRootId,
                    Version=evnt.Version-1
                }, ConfigSettings.ModuleTable);
            });
        }

        /// <summary>删除模块
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModuleChanged evnt)
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
                    ModuleId=evnt.AggregateRootId,
                    Version=evnt.Version-1
                }, ConfigSettings.ModuleTable);
            });
        }

        /// <summary>设置模块可见
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModuleVisibled evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    IsVisible=(int)BoolEnum.True,
                    Version=evnt.Version,
                    EventSequence=evnt.Sequence
                }, new
                {
                    ModuleId = evnt.AggregateRootId,
                    Version = evnt.Version - 1
                }, ConfigSettings.ModuleTable);
            });
        }

        /// <summary>设置模块不可见
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModuleInVisibled evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    IsVisible=(int)BoolEnum.False,
                    Version=evnt.Version,
                    EventSequence=evnt.Sequence
                }, new
                {
                    ModuleId=evnt.AggregateRootId,
                    Version=evnt.Version -1
                }, ConfigSettings.ModuleTable);
            });
        }

        /// <summary>设置模块是否叶子节点
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModuleLeafSetted evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    IsLeaf=evnt.IsLeaf,
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    ModuleId = evnt.AggregateRootId,
                    Version = evnt.Version - 1
                }, ConfigSettings.ModuleTable);
            });
        }

        /// <summary>锁定模块
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModuleLocked evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    Status=ModuleStatus.Locked.ToString(),
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    ModuleId = evnt.AggregateRootId,
                    Version = evnt.Version - 1
                }, ConfigSettings.ModuleTable);
            });
        }

        /// <summary>解锁模块
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModuleUnLock evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    Status = ModuleStatus.Normal.ToString(),
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    ModuleId = evnt.AggregateRootId,
                    Version = evnt.Version - 1
                }, ConfigSettings.ModuleTable);
            });
        }

        /// <summary>添加模块权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModulePermissionAttached evnt)
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
                }, ConfigSettings.ModuleTable, transaction);

                if (effectedRows == 1)
                {
                    var tasks = new List<Task>();
                    foreach (var permissionId in evnt.PermissionIds)
                    {
                        tasks.Add(connection.InsertAsync(new
                        {
                            ModuleId = evnt.AggregateRootId,
                            PermissionId = permissionId
                        }, ConfigSettings.ModulePermissionTable, transaction));
                    }
                    await Task.WhenAll(tasks);
                }
            });
        }

        /// <summary>更新模块权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModulePermissionUpdated evnt)
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
                }, ConfigSettings.ModuleTable, transaction);

                if (effectedRows == 1)
                {
                    var tasks = new List<Task>();
                    //删除全部原先权限
                    tasks.Add(connection.DeleteAsync(new
                    {
                        ModuleId=evnt.AggregateRootId
                    }, ConfigSettings.ModulePermissionTable, transaction));

                    //添加新权限
                    foreach (var permissionId in evnt.PermissionIds)
                    {
                        tasks.Add(connection.InsertAsync(new
                        {
                            ModuleId = evnt.AggregateRootId,
                            PermissionId = permissionId
                        }, ConfigSettings.ModulePermissionTable, transaction));
                    }
                    await Task.WhenAll(tasks);
                }
            });
        }

        /// <summary>删除模块权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(ModulePermissionDetached evnt)
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
                }, ConfigSettings.ModuleTable, transaction);

                if (effectedRows == 1)
                {
                    await connection.DeleteAsync(new
                    {
                        ModuleId=evnt.AggregateRootId
                    }, ConfigSettings.ModulePermissionTable, transaction);
                }
            });
        }
    }
}
