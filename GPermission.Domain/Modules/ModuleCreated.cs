using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>创建模块事件
    /// </summary>
    [Serializable]
    public class ModuleCreated : DomainEvent<string>
    {
        public ModuleInfo Info { get; private set; }
        public string VerifyType { get; private set; }
        public int IsVisible { get; private set; }
        public ModuleCreated()
        {

        }

        public ModuleCreated(Module module, ModuleInfo info,string verifyType,int isVisible) : base()
        {
            Info = info;
            VerifyType = verifyType;
            IsVisible = isVisible;
        }
    }
}
