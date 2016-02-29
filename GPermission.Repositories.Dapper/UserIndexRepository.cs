using ECommon.Components;
using GPermission.Common;
using GPermission.Domain.Repositories;
using GPermission.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommon.Dapper;
namespace GPermission.Repositories.Dapper
{
    /// <summary>用户领域仓储
    /// </summary>
    [Component]
    public class UserIndexRepository : BaseRepository, IUserIndexRepository
    {
        /// <summary>根据代码查询用户索引
        /// </summary>
        public UserCodeIndex FindByCode(string code)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList(new { Code = code }, ConfigSettings.UserCodeIndexTable).FirstOrDefault();
                if (data != null)
                {
                    return new UserCodeIndex(data.UserId, data.Code);
                }
                return null;
            }
        }

        /// <summary>创建用户代码索引
        /// </summary>
        public void Add(UserCodeIndex index)
        {
            using (var connection = GetConnection())
            {
                connection.Insert(new
                {
                    UserId=index.UserId,
                    Code=index.Code
                }, ConfigSettings.UserCodeIndexTable);
            }
        }

        /// <summary>删除用户代码索引
        /// </summary>
        public void Delete(UserCodeIndex index)
        {
            using(var connection=GetConnection())
            {
                connection.Delete(new
                {
                    UserId=index.UserId
                }, ConfigSettings.UserCodeIndexTable);
            }
        }
    }
}
