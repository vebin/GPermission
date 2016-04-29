using ENode.Commanding;

namespace GPermission.Commands.Users
{
    /// <summary>锁定用户命令
    /// </summary>
    public class LockedUser:Command<string>
    {
        public LockedUser()
        {
        }

        public LockedUser(string id) : base(id)
        {
        }
    }
}
