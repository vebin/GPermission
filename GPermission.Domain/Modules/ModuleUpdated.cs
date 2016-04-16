using ENode.Eventing;
using System;

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

        public ModuleUpdated(ModuleEditableInfo info, string verifyType, int isVisiable)
        {
            Info = info;
            VerifyType = verifyType;
            IsVisiable = isVisiable;
        }
    }
}
