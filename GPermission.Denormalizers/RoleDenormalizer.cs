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
    }
}
