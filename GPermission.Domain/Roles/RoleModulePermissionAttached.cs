using ENode.Eventing;
using System.Collections.Generic;

namespace GPermission.Domain.Roles
{
    /// <summary>添加角色模块权限事件
    /// </summary>
    public class RoleModulePermissionAttached : DomainEvent<string>
    {
        public List<string> ModulePermissionIds { get; private set; }

        public RoleModulePermissionAttached()
        {

        }

        public RoleModulePermissionAttached(List<string> modulePermissionIds)
        {
            ModulePermissionIds = modulePermissionIds;
        }
    }
}
