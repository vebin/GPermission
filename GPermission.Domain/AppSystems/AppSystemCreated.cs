using ENode.Eventing;

namespace GPermission.Domain.AppSystems
{
    /// <summary>创建应用系统事件
    /// </summary>

    public class AppSystemCreated : DomainEvent<string>
    {
        public AppSystemInfo Info { get; private set; }
        public string SafeKey { get; private set; }

        public AppSystemCreated()
        {

        }

        public AppSystemCreated(AppSystemInfo info, string safeKey)
        {
            Info = info;
            SafeKey = safeKey;
        }
    }
}
