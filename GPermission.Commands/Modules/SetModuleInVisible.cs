using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Modules
{
    /// <summary>设置模块不可见命令
    /// </summary>
    public class SetModuleInVisible : Command<string>
    {
        public SetModuleInVisible()
        {

        }

        public SetModuleInVisible(string id) : base(id)
        {

        }
    }
}
