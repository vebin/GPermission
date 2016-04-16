using ENode.Eventing;

namespace GPermission.Domain.Permissions
{
    /// <summary>设置权限可见事件
    /// </summary>
    public class PermissionVisibled:DomainEvent<string>
    {

        public PermissionVisibled()
        {

        }

    }
}
