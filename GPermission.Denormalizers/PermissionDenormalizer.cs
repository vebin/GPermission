using ENode.Infrastructure;
using GPermission.Domain.Permissions;
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
    /// <summary>权限持久化
    /// </summary>
    public class PermissionDenormalizer : AbstractDenormalizer
        , IMessageHandler<PermissionCreated>                                            //创建权限
        , IMessageHandler<PermissionUpdated>                                            //更新权限
        , IMessageHandler<PermissionChanged>                                            //删除权限
        , IMessageHandler<PermissionVisibled>                                           //设置权限可见
        , IMessageHandler<PermissionInVisibled>                                         //设置权限不可见
        , IMessageHandler<PermissionLocked>                                             //锁定权限
        , IMessageHandler<PermissionUnLock>                                             //解锁权限
    {

        /// <summary>创建权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(PermissionCreated evnt)
        {
            return TryInsertRecordAsync(connection =>
            {
                var info = evnt.Info;
                return connection.InsertAsync(new
                {
                    PermissionId=evnt.AggregateRootId,
                    AppSystemId=info.AppSystemId,
                    Code=info.Code,
                    Name=info.Name,
                    PermissionType=info.PermissionType,
                    ParentPermission=info.ParentPermission,
                    AssemblyName=info.AssemblyName,
                    FullName=info.FullName,
                    PermissionUrl=info.PermissionUrl,
                    Sort=info.Sort,
                    IsVisible=evnt.IsVisible,
                    Status=PermissionStatus.Normal.ToString(),
                    UseFlag=(int)UseFlag.Useable,
                    Describe=info.Descrbie,
                    ReMark=info.ReMark,
                    Version=evnt.Version,
                    EventSequence=evnt.Sequence
                }, ConfigSettings.PermissionTable);
            });
        }

        /// <summary>更新权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(PermissionUpdated evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                var info = evnt.Info;
                return connection.UpdateAsync(new
                {
                    Name = info.Name,
                    PermissionType = info.PermissionType,
                    ParentPermission = info.ParentPermission,
                    AssemblyName = info.AssemblyName,
                    FullName = info.FullName,
                    PermissionUrl=info.PermissionUrl,
                    Sort=info.Sort,
                    Describe=info.Describe,
                    ReMark=info.ReMark,
                    Version=evnt.Version,
                    EventSequence=evnt.Sequence
                }, new
                {
                    PermissionId=evnt.AggregateRootId,
                    Version=evnt.Version-1
                }, ConfigSettings.PermissionTable);
            });
        }

        /// <summary>删除权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(PermissionChanged evnt)
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
                    PermissionId = evnt.AggregateRootId,
                    Version = evnt.Version - 1
                }, ConfigSettings.PermissionTable);
            });
        }

        /// <summary>设置权限可见
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(PermissionVisibled evnt)
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
                    PermissionId=evnt.AggregateRootId,
                    Version=evnt.Version-1
                }, ConfigSettings.PermissionTable);
            });
        }

        /// <summary>设置权限不可见
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(PermissionInVisibled evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    IsVisible=(int)BoolEnum.False,
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    PermissionId = evnt.AggregateRootId,
                    Version = evnt.Version - 1
                }, ConfigSettings.PermissionTable);
            });
        }

        /// <summary>锁定权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(PermissionLocked evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    Status = PermissionStatus.Locked.ToString(),
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    PermissionId = evnt.AggregateRootId,
                    Version = evnt.Version - 1
                }, ConfigSettings.PermissionTable);
            });
        }

        /// <summary>解锁权限
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(PermissionUnLock evnt)
        {
            return TryUpdateRecordAsync(connection =>
            {
                return connection.UpdateAsync(new
                {
                    Status = PermissionStatus.Normal.ToString(),
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, new
                {
                    PermissionId = evnt.AggregateRootId,
                    Version = evnt.Version - 1
                }, ConfigSettings.PermissionTable);
            });
        }
    }
}
