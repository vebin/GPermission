using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.IQueryServices.DTOs
{
    /// <summary>用户信息DTO
    /// </summary>
    public class UserInfo
    {
        /// <summary>用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>所属系统Id
        /// </summary>
        public string AppSystemId { get; set; }
        /// <summary>用户代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>用户状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>备注
        /// </summary>
        public string ReMark { get; set; }
    }
}
