using ENode.Eventing;

namespace GPermission.Domain.Users
{
    /// <summary>创建账号
    /// </summary>
    public class UserCreated : DomainEvent<string>
    {
        public UserInfo Info { get; private set; }

        public UserCreated()
        {

        }

        public UserCreated(UserInfo info) 
        {
            Info = info;
        }
    }
}
