using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>删除用户角色
    /// </summary>
    [Serializable]
    public class UserRoleRemoved : DomainEvent<string>
    {
        public string RoleId { get; private set; }

        public UserRoleRemoved()
        {
        }
        public UserRoleRemoved(User user,string roleId) : base()
        {
            RoleId = roleId;
        }
    }
}
