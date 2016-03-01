using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Accounts
{
    /// <summary>删除账号事件
    /// </summary>
    [Serializable]
    public class AccountChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }

        public AccountChanged()
        {
        }

        public AccountChanged(Account account, int useFlag) : base()
        {
            UseFlag = useFlag;
        }
    }
}
