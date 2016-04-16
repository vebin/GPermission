using ENode.Eventing;
using System.Collections.Generic;

namespace GPermission.Domain.Accounts
{
    /// <summary>重新设置账号下的系统事件
    /// </summary>
    public class AppSystemReset : DomainEvent<string>
    {
        public List<string> AppSystemIds { get; private set; }

        public AppSystemReset()
        {
        }

        public AppSystemReset(List<string> appSystemIds)
        {
            AppSystemIds = appSystemIds;
        }
    }
}
