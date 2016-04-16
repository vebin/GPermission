using ENode.Eventing;

namespace GPermission.Domain.AppSystems
{
    /// <summary>删除应用系统事件
    /// </summary>
    public class AppSystemChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }

        public AppSystemChanged()
        {

        }

        public AppSystemChanged(int useFlag)
        {
            UseFlag = useFlag;
        }
    }
}
