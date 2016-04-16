using ENode.Eventing;

namespace GPermission.Domain.Accounts
{
    /// <summary>移除应用系统事件
    /// </summary>
    public class AppSystemDetached : DomainEvent<string>
    {
        public string AppSystemId { get; private set; }

        public AppSystemDetached()
        {

        }

        public AppSystemDetached(string appSystemId)
        {
            AppSystemId = appSystemId;
        }
    }
}
