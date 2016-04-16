using ENode.Eventing;
using System;
using System.Collections.Generic;

namespace GPermission.Domain.Modules
{
    /// <summary>添加模块权限事件
    /// </summary>
    public class ModulePermissionAttached : DomainEvent<string>
    {
        public Dictionary<string,string> Permissions { get; private set; }

        public ModulePermissionAttached()
        {

        }

        public ModulePermissionAttached(Dictionary<string, string> permissions)
        {
            Permissions = permissions;
        }
    }
}
