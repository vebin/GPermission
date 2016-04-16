using ENode.Eventing;

namespace GPermission.Domain.Roles
{
    /// <summary>角色模块权限移除事件
    /// </summary>
    public class RoleModulePermissionDetached : DomainEvent<string>
    {
        public string ModulePermissionId { get; private set; }

        public RoleModulePermissionDetached()
        {

        }

        public RoleModulePermissionDetached(string modulePermissionId)
        {
            ModulePermissionId = modulePermissionId;
        }
    }
}
