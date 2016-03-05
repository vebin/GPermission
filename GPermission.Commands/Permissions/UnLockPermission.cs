using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Permissions
{
    /// <summary>解锁权限
    /// </summary>
    public class UnLockPermission : Command<string>
    {
        public UnLockPermission()
        {

        }

        public UnLockPermission(string id) : base(id)
        {

        }
    }
}
