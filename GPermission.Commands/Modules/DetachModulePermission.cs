using ENode.Commanding;

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
