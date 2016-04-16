using ENode.Eventing;
using System;

namespace GPermission.Domain.Modules
{
    /// <summary>创建模块事件
    /// </summary>
    public class ModuleCreated : DomainEvent<string>
    {
        public ModuleInfo Info { get; private set; }
        public string VerifyType { get; private set; }
        public int IsVisible { get; private set; }
        public ModuleCreated()
        {

        }

        public ModuleCreated(ModuleInfo info, string verifyType, int isVisible)
        {
            Info = info;
            VerifyType = verifyType;
            IsVisible = isVisible;
        }
    }
}
