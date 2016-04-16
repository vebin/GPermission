using ENode.Eventing;
namespace GPermission.Domain.Permissions
{
    /// <summary>创建权限事件
    /// </summary>
    public class PermissionCreated:DomainEvent<string>
    {
        public PermissionInfo Info { get; private  set; }
        public int IsVisible { get; private set; }
        public PermissionCreated()
        {
        }
        public PermissionCreated( PermissionInfo info,int isVisible) 
        {
            Info = info;
            IsVisible = isVisible;
        }
    }
}
