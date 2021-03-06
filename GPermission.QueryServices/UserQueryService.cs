﻿using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using System.Collections.Generic;
using System.Linq;
using GPermission.IQueryServices;
using GPermission.IQueryServices.DTOs;

namespace GPermission.QueryServices
{
    /// <summary>用户查询
    /// </summary>
    public class UserQueryService:BaseQueryService,IUserQueryService
    {
        /// <summary>根据用户Id查询用户账号
        /// </summary>
        public UserInfo FindById(string userId)
        {
            using(var connection=GetConnection())
            {
                var data = connection.QueryList<UserInfo>(new
                {
                    UserId=userId,
                    UseFlag=(int)UseFlag.Useable
                }, ConfigSettings.UserTable).FirstOrDefault();
                return data;
            }
        }

        /// <summary>根据用户代码查询用户
        /// </summary>
        public UserInfo FindByCode(string appSystemId, string code)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList<UserInfo>(new
                {
                    AppSystemId=appSystemId,
                    Code = code,
                    UseFlag = (int)UseFlag.Useable
                }, ConfigSettings.UserTable).FirstOrDefault();
                return data;
            }
        }

        /// <summary>查询某个系统下所有用户
        /// </summary>
        public IEnumerable<UserInfo> FindAllByAppSystemId(string appSystemId)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList<UserInfo>(new
                {
                    AppSystemId = appSystemId,
                    UseFlag=(int)UseFlag.Useable
                }, ConfigSettings.UserTable);
                return data;
            }
        }
    }
}
