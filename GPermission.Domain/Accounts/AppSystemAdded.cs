using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Accounts
{
    /// <summary>添加账号关联系统事件
    /// </summary>
    [Serializable]
    public class AppSystemAdded : DomainEvent<string>
    {
        public List<string> AppSystemIds { get; private set; }
        public AppSystemAdded()
        {

        }

        public AppSystemAdded(Account account, List<string> appSystemIds) : base()
        {
            AppSystemIds = appSystemIds;
        }
    }
}
