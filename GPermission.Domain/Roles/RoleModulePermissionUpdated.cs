using ENode.Eventing;
using System.Collections.Generic;

namespace GPermission.Domain.Roles
{
    /// <summary>角色模块权限更新事件
    /// </summary>

    public class RoleModulePermissionUpdated : DomainEvent<string>
    {
        public List<string> ModulePermissionIds { get; private set; }

        public RoleModulePermissionUpdated()
        {

        }

        public RoleModulePermissionUpdated( List<string> modulePermissionIds) 
        {
            ModulePermissionIds = modulePermissionIds;
        }
    }
}
