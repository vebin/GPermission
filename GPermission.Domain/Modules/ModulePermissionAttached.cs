using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>添加模块权限事件
    /// </summary>
    [Serializable]
    public class ModulePermissionAttached : DomainEvent<string>
    {
        public Dictionary<string,string> Permissions { get; private set; }

        public ModulePermissionAttached()
        {

        }

        public ModulePermissionAttached(Module module, Dictionary<string, string> permissions) : base()
        {
            Permissions = permissions;
        }
    }
}
