﻿using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Permissions
{
    /// <summary>创建权限事件
    /// </summary>
    [Serializable]
    public class PermissionCreated:DomainEvent<string>
    {
        public PermissionInfo Info { get; private  set; }
        public int IsVisible { get; private set; }
        public PermissionCreated()
        {
        }
        public PermissionCreated(Permission permission, PermissionInfo info,int isVisible) : base()
        {
            Info = info;
            IsVisible = isVisible;
        }
    }
}
