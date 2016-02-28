using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Users
{
    /// <summary>账号信息实体
    /// </summary>
    public class UserInfo
    {
        /// <summary>账号编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>所属系统Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>账号创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public UserInfo()
        {

        }

        public UserInfo(string code)
        {
            Code = code;
            CreateTime = DateTime.Now;
        }
    }
}
