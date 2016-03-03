using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Permissions
{
    /// <summary>设置权限可见事件
    /// </summary>
    [Serializable]
    public class PermissionVisibled:DomainEvent<string>
    {

        public PermissionVisibled()
        {

        }

        public PermissionVisibled(Permission permission) : base()
        {

        }
    }
}
