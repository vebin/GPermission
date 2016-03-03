﻿using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>更新模块权限事件
    /// </summary>
    [Serializable]
    public class ModulePermissionUpdated : DomainEvent<string>
    {
        public List<string> PermissionIds { get; private set; }

        public ModulePermissionUpdated()
        {

        }

        public ModulePermissionUpdated(Module module,List<string> permissionIds) : base()
        {
            PermissionIds = permissionIds;
        }
    }
}
