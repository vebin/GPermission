using ENode.Eventing;

namespace GPermission.Domain.AppSystems
{
    /// <summary>修改应用信息
    /// </summary>
    public class AppSystemUpdated:DomainEvent<string>
    {
        public AppSystemEditableInfo Info { get; private set; }

        public AppSystemUpdated()
        {

        }

        public AppSystemUpdated(AppSystemEditableInfo info)
        {
            Info = info;
        }
    }
}
