using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Modules
{
    /// <summary>移除模块权限命令
    /// </summary>
    public class DetachModulePermission : Command<string>
    {
        public string ModulePermissionId { get; set; }

        public DetachModulePermission()
        {

        }

        public DetachModulePermission(string id, string modulePermissionId) : base(id)
        {
            ModulePermissionId = modulePermissionId;
        }
    }
}
