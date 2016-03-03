using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>解锁模块事件
    /// </summary>
    [Serializable]
    public class ModuleUnLock:DomainEvent<string>
    {
        public ModuleUnLock()
        {

        }

        public ModuleUnLock(Module module) : base()
        {

        }
    }
}
