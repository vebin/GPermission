using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>用户代码索引
    /// </summary>
    public class UserCodeIndex
    {
        public string UserId { get; set; }

        public string Code { get; set; }

        public UserCodeIndex(string userId, string code)
        {
            UserId = userId;
            Code = code;
        }
    }
}
