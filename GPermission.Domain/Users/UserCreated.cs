using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>创建账号
    /// </summary>
    [Serializable]
    public class UserCreated : DomainEvent<string>
    {
        public UserInfo Info { get; private set; }

        public UserCreated()
        {

        }

        public UserCreated(User account, UserInfo info) : base()
        {
            Info = info;
        }
    }
}
