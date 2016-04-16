using ENode.Eventing;

namespace GPermission.Domain.Users
{
    /// <summary>删除账号事件
    /// </summary>

    public class UserChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }

        public UserChanged()
        {

        }

        public UserChanged( int useFlag) 
        {
            UseFlag = useFlag;
        }
    }
}
