using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Users
{
    /// <summary>解锁用户命令
    /// </summary>
    public class UnLockedUser : Command<string>
    {
        public UnLockedUser()
        {

        }

        public UnLockedUser(string id) : base(id)
        {
        }
    }
}
