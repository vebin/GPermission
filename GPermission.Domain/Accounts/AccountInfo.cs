using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Accounts
{
    /// <summary>账号信息实体
    /// </summary>
    public class AccountInfo
    {
        /// <summary>账号登陆名
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>账号密码
        /// </summary>
        public string AccountPassword { get; set; }
        /// <summary>创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public AccountInfo(string accountName, string accountPassword)
        {
            AccountName = accountName;
            AccountPassword = accountPassword;
            CreateTime = DateTime.Now;
        }
    }
}
