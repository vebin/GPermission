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
    public class UserRoleAdded : DomainEvent<string>
    {
        public List<string> RoleIds { get; private set; }

        public UserRoleAdded()
        {

        }

        public UserRoleAdded(User user,List<string> roleIds) : base()
        {
            RoleIds = roleIds;
        }
    }
}
