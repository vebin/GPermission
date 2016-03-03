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
    public class LockedModule:Command<string>
    {
        public LockedModule()
        {

        }

        public LockedModule(string id):base(id)
        {

        }
    }
}
