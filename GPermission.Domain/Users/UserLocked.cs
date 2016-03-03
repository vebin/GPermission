using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>锁定用户账号
    /// </summary>
    [Serializable]
    public class UserLocked : DomainEvent<string>
    {
        public UserLocked()
        {

        }

        public UserLocked(User user) : base()
        {

        }
    }
}
