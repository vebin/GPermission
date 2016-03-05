using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Roles
{
    /// <summary>角色模块权限移除事件
    /// </summary>
    [Serializable]
    public class RoleModulePermissionDetached : DomainEvent<string>
    {
        public string ModulePermissionId { get; private set; }

        public RoleModulePermissionDetached()
        {

        }

        public RoleModulePermissionDetached(Role role, string modulePermissionId) : base()
        {
            ModulePermissionId = modulePermissionId;
        }
    }
}
