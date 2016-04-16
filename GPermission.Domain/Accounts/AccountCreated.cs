using ENode.Eventing;

namespace GPermission.Domain.Accounts
{
    /// <summary>创建账号事件
    /// </summary>
    public class AccountCreated : DomainEvent<string>
    {
        public AccountInfo Info { get; private set; }

        public AccountCreated()
        {
        }

        public AccountCreated(AccountInfo info)
        {
            Info = info;
        }
    }
}
