using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>重置用户角色事件
    /// </summary>
    [Serializable]
    public class UserRoleReset : DomainEvent<string>
    {
        public List<string> RoleIds { get; private set; }

        public UserRoleReset()
        {
        }
        public UserRoleReset(User user, List<string> roleIds) : base()
        {
            RoleIds = roleIds;
        }
    }
}
