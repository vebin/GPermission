using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Modules
{
    /// <summary>删除模块命令
    /// </summary>
    public class ChangeModule : Command<string>
    {
        public int UseFlag { get; set; }

        public ChangeModule()
        {

        }

        public ChangeModule(string id, int useFlag) : base(id)
        {
            UseFlag = useFlag;
        }
    }
}
