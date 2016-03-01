using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Accounts
{
    /// <summary>创建账号事件
    /// </summary>
    [Serializable]
    public class AccountCreated : DomainEvent<string>
    {
        public AccountInfo Info { get; private set; }

        public AccountCreated()
        {
        }
        public AccountCreated(Account account, AccountInfo info) : base()
        {
            Info = info;
        }
    }
}
