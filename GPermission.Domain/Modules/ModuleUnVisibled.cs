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
    public class ModuleUnVisibled : DomainEvent<string>
    {
        public ModuleUnVisibled()
        {

        }

        public ModuleUnVisibled(Module module) : base()
        {

        }
    }
}
