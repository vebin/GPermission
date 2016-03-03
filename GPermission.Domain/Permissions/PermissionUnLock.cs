using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Permissions
{
    /// <summary>权限解锁事件
    /// </summary>
    [Serializable]
    public class PermissionUnLock : DomainEvent<string>
    {
        public PermissionUnLock()
        {

        }

        public PermissionUnLock(Permission permission) : base()
        {

        }
    }
}
