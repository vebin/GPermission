using ENode.Eventing;

namespace GPermission.Domain.Roles
{
    /// <summary>删除角色事件
    /// </summary>
    public class RoleChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }

        public RoleChanged()
        {

        }

        public RoleChanged(int useFlag) 
        {
            UseFlag = useFlag;
        }
    }
}
