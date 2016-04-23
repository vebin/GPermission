using ENode.Eventing;

namespace GPermission.Domain.AppSystems
{
    /// <summary>密钥更新事件
    /// </summary>
    public class SafeKeyUpdated:DomainEvent<string>
    {
        public string SafeKey { get; private set; }

        public SafeKeyUpdated()
        {
            
        }

        public SafeKeyUpdated(string safeKey)
        {
            SafeKey = safeKey;
        }

    }
}
