using ENode.Commanding;
using System.Collections.Generic;

namespace GPermission.Commands.Modules
{
    /// <summary>更新模块权限命令
    /// </summary>
    public class UpdateModulePermission : Command<string>
    {
        public Dictionary<string, string> Permissions { get; set; }

        public UpdateModulePermission()
        {

        }

        public UpdateModulePermission(string id, Dictionary<string, string> permissions) : base(id)
        {
            Permissions = permissions;
        }
    }
}
