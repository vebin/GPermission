using ENode.Eventing;

namespace GPermission.Domain.Modules
{
    /// <summary>删除模块权限事件
    /// </summary>

    public class ModulePermissionDetached : DomainEvent<string>
    {
        public string ModulePermissionId { get; private set; }

        public ModulePermissionDetached()
        {

        }

        public ModulePermissionDetached(string modulePermissionId)
        {
            ModulePermissionId = modulePermissionId;
        }
    }
}
