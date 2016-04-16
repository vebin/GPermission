using ENode.Eventing;
using System.Collections.Generic;

namespace GPermission.Domain.Users
{
    /// <summary>用户角色添加
    /// </summary>
    public class UserRoleAttached : DomainEvent<string>
    {
        public List<string> RoleIds { get; private set; }

        public UserRoleAttached()
        {

        }

        public UserRoleAttached(List<string> roleIds)
        {
            RoleIds = roleIds;
        }
    }
}
