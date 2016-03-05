using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Roles
{
    /// <summary>添加角色模块权限事件
    /// </summary>
    [Serializable]
    public class RoleModulePermissionAttached : DomainEvent<string>
    {
        public List<string> ModulePermissionIds { get; private set; }

        public RoleModulePermissionAttached()
        {

        }

        public RoleModulePermissionAttached(Role role, List<string> modulePermissionIds) : base()
        {
            ModulePermissionIds = modulePermissionIds;
        }
    }
}
