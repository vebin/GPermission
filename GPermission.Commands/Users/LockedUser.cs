using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
