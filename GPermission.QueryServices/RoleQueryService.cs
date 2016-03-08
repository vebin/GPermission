using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using GPermission.IQueryServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
