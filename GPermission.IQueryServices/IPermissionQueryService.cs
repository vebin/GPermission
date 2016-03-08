using GPermission.IQueryServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.IQueryServices
{
    /// <summary>权限查询接口
    /// </summary>
    public interface IPermissionQueryService
    {
        /// <summary>根据Id查询权限
        /// </summary>
        PermissionInfo FindById(string permissionId);

        /// <summary>根据权限代码查询权限
        /// </summary>
        PermissionInfo FindByCode(string appSystemId, string code);

        /// <summary>查询最高级权限
        /// </summary>
        IEnumerable<PermissionInfo> FindHighests(string appSystemId, string permissionType);

        /// <summary>查询所有子权限
        /// </summary>
        IEnumerable<PermissionInfo> FindSons(string appSystemId, string permissionType, string parentPermission);

        /// <summary>查询模块下的权限
        /// </summary>
        IEnumerable<PermissionInfo> FindModulePermission(string appSystemId, string moduleId);
    }
}
