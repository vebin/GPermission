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
