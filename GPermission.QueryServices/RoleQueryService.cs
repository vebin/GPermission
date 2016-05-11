using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using GPermission.IQueryServices.DTOs;

namespace GPermission.QueryServices
{
    /// <summary>角色相关查询
    /// </summary>
    public class RoleQueryService : BaseQueryService, IRoleQueryService
    {
        /// <summary>根据角色Id查询角色信息
        /// </summary>
        public RoleInfo FindById(string roleId)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<RoleInfo>(new
                {
                    RoleId = roleId,
                    UseFlag = (int)UseFlag.Useable
                }, ConfigSettings.RoleTable).FirstOrDefault();
            }
        }

        /// <summary>根据系统Id,角色代码查询角色信息
        /// </summary>
        public RoleInfo FindByCode(string appSystemId, string code)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList(new
                {
                    AppSystemId = appSystemId,
                    Code = code,
                    UseFlag = (int)UseFlag.Useable
                }, ConfigSettings.RoleTable).FirstOrDefault();
            }
        }

        /// <summary>根据系统Id查询所有的角色
        /// </summary>
        public IEnumerable<RoleInfo> FindAll(string appSystemId)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<RoleInfo>(new
                {
                    AppSystemId = appSystemId,
                    UseFlag = (int)UseFlag.Useable
                }, ConfigSettings.RoleTable);
            }
        }

        /// <summary>根据用户Id,查询用户所拥有的角色
        /// </summary>
        public IEnumerable<RoleInfo> FindUserRole(string userId)
        {
            using (var connection = GetConnection())
            {
                string sql = string.Format(
                    "select * from {0} a inner join {1} b on a.RoleId=b.RoleId where b.UserId=@UserId and a.UseFlag=@UseFlag",
                    ConfigSettings.RoleTable, ConfigSettings.UserRoleTable);
                return connection.Query<RoleInfo>(sql, new {UserId = userId, UseFlag = (int) UseFlag.Useable});
            }
        }
    }
}
