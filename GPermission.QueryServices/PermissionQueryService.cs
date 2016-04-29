using Dapper;
using ECommon.Dapper;
using GPermission.Common;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using System.Collections.Generic;
using System.Linq;
using GPermission.IQueryServices.DTOs;

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
        
        /// <summary>根据权限代码查询权限
        /// </summary>
        public PermissionInfo FindByCode(string appSystemId, string code)
        {
            using(var connection=GetConnection())
            {
                return connection.QueryList<PermissionInfo>(new
                {
                    AppSystemId=appSystemId,
                    Code=code,
                    UseFlag=(int)UseFlag.Useable
                }, ConfigSettings.PermissionTable).FirstOrDefault();
            }
        }

        /// <summary>查询最高级权限
        /// </summary>
        public IEnumerable<PermissionInfo> FindHighests(string appSystemId,string permissionType)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<PermissionInfo>(new
                {
                    AppSystemId = appSystemId,
                    PermissionType = permissionType,
                    UseFlag = (int)UseFlag.Useable
                }, ConfigSettings.PermissionTable);
            }
        }

        /// <summary>查询所有子权限
        /// </summary>
        public IEnumerable<PermissionInfo> FindSons(string appSystemId, string permissionType, string parentPermission)
        {
            using (var connection = GetConnection())
            {
                return connection.QueryList<PermissionInfo>(new
                {
                    AppSystemId = appSystemId,
                    PermissionType = permissionType,
                    ParentPermission=parentPermission,
                    UseFlag = (int)UseFlag.Useable
                }, ConfigSettings.PermissionTable);
            }
        }

        /// <summary>查询模块下的权限
        /// </summary>
        public IEnumerable<PermissionInfo> FindModulePermission(string appSystemId,string moduleId)
        {
            using (var connection = GetConnection())
            {
                string sql = string.Format(@"Select b.* from {0} a inner join {1} b on a.ModuleId=b.ModuleId where a.ModuleId=@ModuleId and a.ModuleId=@ModuleId and b.UseFlag=@UseFlag", ConfigSettings.PermissionTable, ConfigSettings.ModulePermissionTable);
                var data = connection.Query<PermissionInfo>(sql, new { AppSystemId = appSystemId, ModuleId = moduleId, UseFlag = (int)UseFlag.Useable });
                return data;
            }
        }
    }

}
