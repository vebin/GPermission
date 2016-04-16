using ENode.Eventing;
namespace GPermission.Domain.Roles
{
    /// <summary>创建角色事件
    /// </summary>
    public class RoleCreated : DomainEvent<string>
    {
        public RoleInfo Info { get; private set; }
        public int IsEnabled { get; private set; }

        public RoleCreated()
        {

        }
        public RoleCreated(RoleInfo info,int isEnabled)
        {
            Info = info;
            IsEnabled = isEnabled;
        }
    }
}
