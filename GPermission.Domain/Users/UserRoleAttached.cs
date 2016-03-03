using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>用户角色添加
    /// </summary>
    [Serializable]
    public class UserRoleAttached : DomainEvent<string>
    {
        public List<string> RoleIds { get; private set; }

        public UserRoleAttached()
        {

        }

        public UserRoleAttached(User user,List<string> roleIds) : base()
        {
            RoleIds = roleIds;
        }
    }
}
