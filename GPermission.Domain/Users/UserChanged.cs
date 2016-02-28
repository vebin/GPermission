using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>删除账号事件
    /// </summary>
    [Serializable]
    public class UserChanged : DomainEvent<string>
    {
        public int UseFlag { get; private set; }

        public UserChanged()
        {

        }

        public UserChanged(User user,int useFlag) : base()
        {
            UseFlag = useFlag;
        }
    }
}
