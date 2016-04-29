using ENode.Commanding;
using System;
using System.Collections.Generic;

namespace GPermission.Commands.Users
{
    /// <summary>添加用户角色命令
    /// </summary>
    [Serializable]
    public class AttachUserRole : Command<string>
    {
        public List<string> RoleIds { get; set; }

        public AttachUserRole()
        {
        }

        public AttachUserRole(string id, List<string> roleIds) : base(id)
        {
            RoleIds = roleIds;
        }
    }
}
