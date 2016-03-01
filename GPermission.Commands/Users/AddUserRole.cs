using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Users
{
    /// <summary>添加用户角色命令
    /// </summary>
    [Serializable]
    public class AddUserRole : Command<string>
    {
        public List<string> RoleIds { get; set; }

        public AddUserRole()
        {
        }

        public AddUserRole(string id, List<string> roleIds) : base(id)
        {
            RoleIds = roleIds;
        }
    }
}
