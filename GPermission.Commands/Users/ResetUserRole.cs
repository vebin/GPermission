using ENode.Commanding;
using System;
using System.Collections.Generic;

namespace GPermission.Commands.Users
{
    /// <summary>重置用户角色命令
    /// </summary>
    [Serializable]
    public class ResetUserRole : Command<string>
    {
        public List<string> RoleIds { get; set; }

        public ResetUserRole()
        {

        }

        public ResetUserRole(string id, List<string> roleIds) : base(id)
        {
            RoleIds = roleIds;
        }
    }
}
