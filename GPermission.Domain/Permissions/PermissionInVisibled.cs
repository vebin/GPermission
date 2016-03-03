using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Permissions
{
    /// <summary>权限不可见事件
    /// </summary>
    [Serializable]
    public class PermissionInVisibled : DomainEvent<string>
    {
        public PermissionInVisibled()
        {

        }

        public PermissionInVisibled(Permission permission) : base()
        {

        }
    }
}
