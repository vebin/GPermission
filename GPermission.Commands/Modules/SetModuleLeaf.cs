using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Modules
{
    /// <summary>设置模块是否为叶子节点命令
    /// </summary>
    public class SetModuleLeaf : Command<string>
    {
        public int IsLeaf { get; set; }

        public SetModuleLeaf()
        {

        }

        public SetModuleLeaf(string id,int isLeaf) : base(id)
        {
            IsLeaf = isLeaf;
        }
    }
}
