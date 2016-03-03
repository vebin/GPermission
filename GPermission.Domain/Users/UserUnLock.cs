using ENode.Eventing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>用户解锁
    /// </summary>
    [Serializable]
    public class UserUnLock : DomainEvent<string>
    {
        public UserUnLock()
        {

        }

        public UserUnLock(User user) : base()
        {
            
        }
    }
}
