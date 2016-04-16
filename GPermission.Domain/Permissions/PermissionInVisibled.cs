using ENode.Eventing;

namespace GPermission.Domain.Permissions
{
    /// <summary>权限不可见事件
    /// </summary>
    public class PermissionInVisibled : DomainEvent<string>
    {
        public PermissionInVisibled()
        {

        }

    }
}
