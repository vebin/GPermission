using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Roles
{
    /// <summary>删除角色事件
    /// </summary>
    [Serializable]
    public class RoleChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }

        public RoleChanged()
        {

        }

        public RoleChanged(Role role,int useFlag) : base()
        {
            UseFlag = useFlag;
        }
    }
}
