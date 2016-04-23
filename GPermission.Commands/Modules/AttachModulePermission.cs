using ENode.Commanding;
using System.Collections.Generic;

namespace GPermission.Commands.Modules
{
    /// <summary>添加模块权限命令
    /// </summary>
    public class AttachModulePermission:Command<string>
    {
        public Dictionary<string,string> Permissions { get; set; }

        public AttachModulePermission()
        {

        }

        public AttachModulePermission(string id, Dictionary<string, string> permissions) : base(id)
        {
            Permissions = permissions;
        }
    }
}
