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
    /// <summary>权限查询服务
    /// </summary>
    public class PermissionQueryService : BaseQueryService, IPermissionQueryService
    {
        /// <summary>根据Id查询权限
        /// </summary>
        public PermissionInfo FindById(string permissionId)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList(new
                {
                    PermissionId = permissionId,
                    UseFlag=(int)UseFlag.Useable
                }, ConfigSettings.PermissionTable).FirstOrDefault();
            }
        }
    }

}
