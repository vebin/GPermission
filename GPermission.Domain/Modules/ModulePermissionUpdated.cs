using ENode.Eventing;
using System.Collections.Generic;

namespace GPermission.Domain.Modules
{
    /// <summary>更新模块权限事件
    /// </summary>

    public class ModulePermissionUpdated : DomainEvent<string>
    {
        public Dictionary<string, string> Permissions { get; private set; }

        public ModulePermissionUpdated()
        {

        }

        public ModulePermissionUpdated(Dictionary<string, string> permissions)
        {
            Permissions = permissions;
        }
    }
}
