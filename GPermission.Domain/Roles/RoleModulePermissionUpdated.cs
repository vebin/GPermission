using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Roles
{
    /// <summary>角色模块权限更新事件
    /// </summary>
    [Serializable]
    public class RoleModulePermissionUpdated : DomainEvent<string>
    {
        public List<string> ModulePermissionIds { get; private set; }

        public RoleModulePermissionUpdated()
        {

        }

        public RoleModulePermissionUpdated(Role role, List<string> modulePermissionIds) : base()
        {
            ModulePermissionIds = modulePermissionIds;
        }
    }
}
