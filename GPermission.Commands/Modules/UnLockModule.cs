using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Modules
{
    /// <summary>解锁模块
    /// </summary>
    public class UnLockModule:Command<string>
    {
        public UnLockModule()
        {

        }

        public UnLockModule(string id) : base(id)
        {

        }
    }
}
