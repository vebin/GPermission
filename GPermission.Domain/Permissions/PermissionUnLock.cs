using ENode.Eventing;

namespace GPermission.Domain.Permissions
{
    /// <summary>权限解锁事件
    /// </summary>
    public class PermissionUnLock : DomainEvent<string>
    {
        public PermissionUnLock()
        {

        }
    }
}
