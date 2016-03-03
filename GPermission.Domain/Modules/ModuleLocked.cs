using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>锁定模块事件
    /// </summary>
    [Serializable]
    public class ModuleLocked : DomainEvent<string>
    {
        public ModuleLocked()
        {

        }

        public ModuleLocked(Module module) : base()
        {

        }
    }
}
