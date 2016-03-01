using ECommon.Components;
using ECommon.Dapper;
using GPermission.Common;
using GPermission.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Repositories.Dapper
{
    /// <summary>角色领域仓储
    /// </summary>
    [Component]
    public class RoleRepository:BaseRepository,IRoleRepository
    {
        /// <summary>根据条件查询角色
        /// </summary>
        public IEnumerable<dynamic> QueryRoles(object condition)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList(connection, ConfigSettings.RoleTable);
                return data;
            }
        }
    }
}
