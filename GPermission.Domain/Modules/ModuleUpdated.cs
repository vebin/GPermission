using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>模块更新事件
    /// </summary>
    [Serializable]
    public class ModuleUpdated : DomainEvent<string>
    {
        public ModuleEditableInfo Info { get; private set; }
        public string VerifyType { get; private set; }
        public int IsVisiable { get; private set; }

        public ModuleUpdated()
        {

        }

        public ModuleUpdated(Module module,ModuleEditableInfo info,string verifyType,int isVisiable) : base()
        {
            Info = info;
            VerifyType = verifyType;
            IsVisiable = isVisiable;
        }
    }
}
