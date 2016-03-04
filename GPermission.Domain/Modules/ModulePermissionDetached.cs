using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>删除模块权限事件
    /// </summary>
    [Serializable]
    public class ModulePermissionDetached : DomainEvent<string>
    {
        public string ModulePermissionId { get; private set; }
        public ModulePermissionDetached()
        {

        }

        public ModulePermissionDetached(Module module,string modulePermissionId) : base()
        {
            ModulePermissionId = modulePermissionId;
        }
    }
}
