using ENode.Eventing;
namespace GPermission.Domain.Permissions
{
    /// <summary>删除权限事件
    /// </summary>
    public class PermissionChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }
        public PermissionChanged()
        {
        }

        public PermissionChanged(int useFlag) 
        {
            UseFlag = useFlag;
        }
    }
}
