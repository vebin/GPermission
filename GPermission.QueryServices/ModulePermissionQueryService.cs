using Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.QueryServices
{
    /// <summary>模块权限查询
    /// </summary>
    public class ModulePermissionQueryService : BaseQueryService, IModulePermissionQueryService
    {

        public void FindByRoleId(string appSystemId, string roleId)
        {
            using (var connection = GetConnection())
            {
                string sql = string.Format(@"Select * from {0} a inner join {1} b on a.RoleId=b.RoleId inner join {2} c on b.ModuleId=c.ModuleId inner join {3} d on b.PermissionId=d.PermissionId where a.RoleId=@RoleId and c.AppSystemId=@AppSystemId and c.UseFlag=@UseFlag and d.UseFlag=@UseFlag", ConfigSettings.RoleModulePermissionTable, ConfigSettings.ModulePermissionTable, ConfigSettings.ModuleTable);
                var data = connection.Query(sql, new { AppSystemId = appSystemId, RoleId = roleId, UseFlag = (int)UseFlag.Useable });
            }
        }
    }
}
