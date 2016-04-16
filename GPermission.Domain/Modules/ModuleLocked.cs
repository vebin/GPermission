using ENode.Eventing;

namespace GPermission.Domain.Modules
{
    /// <summary>锁定模块事件
    /// </summary>
    public class ModuleLocked : DomainEvent<string>
    {
        public ModuleLocked()
        {

        }

    }
}
