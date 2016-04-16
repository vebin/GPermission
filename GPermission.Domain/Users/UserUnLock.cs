using ENode.Eventing;

namespace GPermission.Domain.Users
{
    /// <summary>用户解锁
    /// </summary>
    public class UserUnLock : DomainEvent<string>
    {
        public UserUnLock()
        {

        }

    }
}
