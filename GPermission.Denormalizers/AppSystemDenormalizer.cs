using ENode.Infrastructure;
using GPermission.Domain.AppSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommon.IO;
using ECommon.Dapper;
using GPermission.Common.Enums;
using GPermission.Common;

namespace GPermission.Denormalizers
{
    /// <summary>应用系统持久化
    /// </summary>
    public class AppSystemDenormalizer : AbstractDenormalizer
        , IMessageHandler<AppSystemCreated>                                      //创建应用系统
        , IMessageHandler<AppSystemChanged>                                      //删除应用系统
    {

        /// <summary>创建应用系统
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(AppSystemCreated evnt)
        {
            return TryInsertRecordAsync(connection =>
            {
                var info = evnt.Info;
                return connection.InsertAsync(new
                {
                    AppSystemId=evnt.AggregateRootId,
                    Code=info.Code,
                    SafeKey=evnt.SafeKey,
                    Name=info.Name,
                    CreateTime=info.CreateTime,
                    Status="",
                    UseFlag=(int)UseFlag.Useable,
                    ReMark=info.ReMark,
                    Version = evnt.Version,
                    EventSequence = evnt.Sequence
                }, ConfigSettings.AppSystemTable);
            });
        }

        /// <summary>删除应用系统
        /// </summary>
        public Task<AsyncTaskResult> HandleAsync(AppSystemChanged evnt)
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
                    AppSystemId=evnt.AggregateRootId,
                    Version=evnt.Version-1
                }, ConfigSettings.AppSystemTable);
            });
        }
    }
}
