using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Permissions
{
    /// <summary>删除权限事件
    /// </summary>
    [Serializable]
    public class PermissionChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }
        public PermissionChanged()
        {
        }

        public PermissionChanged(Permission permission,int useFlag) : base()
        {
            UseFlag = useFlag;
        }
    }
}
