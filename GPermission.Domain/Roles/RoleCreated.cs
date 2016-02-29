using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Roles
{
    /// <summary>创建角色事件
    /// </summary>
    [Serializable]
    public class RoleCreated : DomainEvent<string>
    {
        public RoleInfo Info { get; private set; }
        public int IsEnabled { get; private set; }

        public RoleCreated()
        {

        }
        public RoleCreated(Role role,RoleInfo info,int isEnabled) : base()
        {
            Info = info;
            IsEnabled = isEnabled;
        }
    }
}
