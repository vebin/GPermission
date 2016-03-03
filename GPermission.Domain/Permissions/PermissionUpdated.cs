using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Permissions
{
    /// <summary>权限更新
    /// </summary>
    [Serializable]
    public class PermissionUpdated : DomainEvent<string>
    {
        public PermissionEditableInfo Info { get; private set; }

        public PermissionUpdated()
        {

        }

        public PermissionUpdated(Permission permission,PermissionEditableInfo info) : base()
        {
            Info = info;
        }
    }
}
