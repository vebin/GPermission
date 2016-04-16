using ENode.Eventing;
namespace GPermission.Domain.Permissions
{
    /// <summary>权限更新
    /// </summary>
    public class PermissionUpdated : DomainEvent<string>
    {
        public PermissionEditableInfo Info { get; private set; }

        public PermissionUpdated()
        {

        }

        public PermissionUpdated(PermissionEditableInfo info)
        {
            Info = info;
        }
    }
}
