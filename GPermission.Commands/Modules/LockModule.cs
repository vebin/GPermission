using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Modules
{
    /// <summary>锁定模块命令
    /// </summary>
    public class LockModule:Command<string>
    {
        public LockModule()
        {

        }

        public LockModule(string id):base(id)
        {

        }
    }
}
