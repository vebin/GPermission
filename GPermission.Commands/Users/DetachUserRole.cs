﻿using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Users
{
    /// <summary>移除用户角色命令
    /// </summary>
    [Serializable]
    public class DetachUserRole:Command<string>
    {
        public string RoleId { get; set; }

        public DetachUserRole()
        {

        }

        public DetachUserRole(string id, string roleId) : base(id)
        {
            RoleId = roleId;
        }
    }
}