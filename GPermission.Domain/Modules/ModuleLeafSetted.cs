using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>设置模块叶子节点状态事件
    /// </summary>
    [Serializable]
    public class ModuleLeafSetted : DomainEvent<string>
    {
        public int IsLeaf { get; private set; }

        public ModuleLeafSetted()
        {
        }

        public ModuleLeafSetted(Module module,int isLeaf) : base()
        {
            IsLeaf = isLeaf;
        }
    }
}
