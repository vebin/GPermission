using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>删除模块事件
    /// </summary>
    [Serializable]
    public class ModuleChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }
        public ModuleChanged()
        {

        }

        public ModuleChanged(Module module, int useFlag)
        {
            UseFlag = useFlag;
        }
    }
}
