using ENode.Eventing;
namespace GPermission.Domain.Permissions
{
    /// <summary>锁定权限事件
    /// </summary>
    public class PermissionLocked : DomainEvent<string>
    {
        public PermissionLocked()
        {

        }

    }
}
