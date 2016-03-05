using ECommon.Components;
using GPermission.Common;
using GPermission.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Services
{
    /// <summary>权限领域服务
    /// </summary>
    [Component]
    public class PermissionService
    {
        private IPermissionRepository _permissionRepository;
        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        /// <summary>检测权限是否存在
        /// </summary>
        public void Exist(string permissionId)
        {
            var permission = _permissionRepository.FindById(permissionId);
            if(permission==null)
            {
                throw new NotExistException("该权限不存在");
            }
        }

    }
}
