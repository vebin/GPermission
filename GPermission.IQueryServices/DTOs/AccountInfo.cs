using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.IQueryServices.DTOs
{
    /// <summary>账号信息Dto
    /// </summary>
    public class AccountInfo
    {
        /// <summary>账号Id
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>账号类型
        /// </summary>
        public string AccountType { get; set; }
        /// <summary>账号密码
        /// </summary>
        public string AccountPassowd { get; set; }
        /// <summary>创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>状态
        /// </summary>
        public string Status { get; set; }
    }
}
