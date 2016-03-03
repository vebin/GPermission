using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Permissions
{
    /// <summary>锁定权限事件
    /// </summary>
    [Serializable]
    public class PermissionLocked : DomainEvent<string>
    {
        public PermissionLocked()
        {

        }

        public PermissionLocked(Permission permission) : base()
        {

        }
    }
}
