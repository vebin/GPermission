using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Accounts
{
    /// <summary>重新设置账号下的系统事件
    /// </summary>
    [Serializable]
    public class AppSystemReset:DomainEvent<string>
    {
        public List<string> AppSystemIds { get; private set; }

        public AppSystemReset()
        {
        }

        public AppSystemReset(Account account, List<string> appSystemIds)
        {
            AppSystemIds = appSystemIds;
        }
    }
}
