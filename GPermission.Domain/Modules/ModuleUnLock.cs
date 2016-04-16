using ENode.Eventing;

namespace GPermission.Domain.Modules
{
    /// <summary>解锁模块事件
    /// </summary>
    public class ModuleUnLock : DomainEvent<string>
    {
        public ModuleUnLock()
        {

        }

    }
}
