using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Permissions
{
    /// <summary>锁定权限命令
    /// </summary>
    public class LockPermission : Command<string>
    {
        public LockPermission()
        {

        }

        public LockPermission(string id) : base(id)
        {
        }
    }
}
