using ENode.Eventing;

namespace GPermission.Domain.Modules
{
    /// <summary>模块不可见事件
    /// </summary>
    public class ModuleInVisibled : DomainEvent<string>
    {
        public ModuleInVisibled()
        {

        }

    }
}
