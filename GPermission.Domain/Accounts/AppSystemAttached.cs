using ENode.Eventing;
using System.Collections.Generic;

namespace GPermission.Domain.Accounts
{
    /// <summary>添加账号关联系统事件
    /// </summary>
    public class AppSystemAttached : DomainEvent<string>
    {
        public List<string> AppSystemIds { get; private set; }
        public AppSystemAttached()
        {

        }

        public AppSystemAttached( List<string> appSystemIds) 
        {
            AppSystemIds = appSystemIds;
        }
    }
}
