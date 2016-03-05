using ECommon.Components;
using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Repositories.Dapper
{
    /// <summary>权限领域仓储
    /// </summary>
    [Component]
    public class PermissionRepository:BaseRepository, IPermissionRepository
    {
        /// <summary>根据权限Id查询权限
        /// </summary>
        public dynamic FindById(string permissionId)
        {
            using (var connection = GetConnection())
            {
                var data = connection.QueryList(new
                {
                    PermissionId = permissionId,
                    UseFlag = (int)UseFlag.Useable
                }, ConfigSettings.PermissionTable).FirstOrDefault();
                return data;
            }
        }
    }
}
