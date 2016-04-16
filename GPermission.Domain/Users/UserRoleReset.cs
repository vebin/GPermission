using ENode.Eventing;
using System.Collections.Generic;

namespace GPermission.Domain.Users
{
    /// <summary>重置用户角色事件
    /// </summary>
    public class UserRoleReset : DomainEvent<string>
    {
        public List<string> RoleIds { get; private set; }

        public UserRoleReset()
        {
        }
        public UserRoleReset(List<string> roleIds) 
        {
            RoleIds = roleIds;
        }
    }
}
