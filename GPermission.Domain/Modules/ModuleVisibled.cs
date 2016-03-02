using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>模块可见事件
    /// </summary>
    [Serializable]
    public class ModuleVisibled : DomainEvent<string>
    {
        public ModuleVisibled()
        {

        }

        public ModuleVisibled(Module module) : base()
        {

        }
    }

}
