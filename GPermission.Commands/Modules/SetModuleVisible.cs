using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Modules
{
    /// <summary>设置模块可见命令
    /// </summary>
    public class SetModuleVisible : Command<string>
    {
        public SetModuleVisible()
        {

        }

        public SetModuleVisible(string id) : base(id)
        {

        }
    }
}
