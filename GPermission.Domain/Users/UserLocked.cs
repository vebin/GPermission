using ENode.Eventing;

namespace GPermission.Domain.Users
{
    /// <summary>锁定用户账号
    /// </summary>
    public class UserLocked : DomainEvent<string>
    {
        public UserLocked()
        {

        }

    }
}
