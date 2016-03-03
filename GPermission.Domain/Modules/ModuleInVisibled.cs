using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>模块不可见事件
    /// </summary>
    [Serializable]
    public class ModuleInVisibled : DomainEvent<string>
    {
        public ModuleInVisibled()
        {

        }

        public ModuleInVisibled(Module module) : base()
        {

        }
    }
}
