using ENode.Eventing;

namespace GPermission.Domain.Modules
{
    /// <summary>删除模块事件
    /// </summary>
    public class ModuleChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }
        public ModuleChanged()
        {

        }

        public ModuleChanged( int useFlag)
        {
            UseFlag = useFlag;
        }
    }
}
