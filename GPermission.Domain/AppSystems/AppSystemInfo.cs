using System;

namespace GPermission.Domain.AppSystems
{
    /// <summary>应用系统信息实体
    /// </summary>
    public class AppSystemInfo
    {
        /// <summary>应用代码(唯一,不可变)
        /// </summary>
        public string Code { get; set; }
        /// <summary>应用名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>账号Id
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>备注
        /// </summary>
        public string ReMark { get; set; }
        /// <summary>创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public AppSystemInfo()
        {

        }

        public AppSystemInfo(string code, string name,string accountId, string reMark = "")
        {
            Code = code;
            Name = name;
            AccountId = accountId;
            ReMark = reMark;
            CreateTime = DateTime.Now;
        }
    }
}
