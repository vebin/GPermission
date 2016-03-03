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
    public class UnLockedModule:Command<string>
    {
        public UnLockedModule()
        {

        }

        public UnLockedModule(string id) : base(id)
        {

        }
    }
}
