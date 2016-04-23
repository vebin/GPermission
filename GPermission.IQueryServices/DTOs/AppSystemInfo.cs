using System;

namespace GPermission.IQueryServices.Dtos
{
    /// <summary>应用系统基础信息实体
    /// </summary>
    public class AppSystemInfo
    {
        /// <summary>应用系统Id
        /// </summary>
        public string AppSystemId { get; set; }
        /// <summary>应用系统代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>安全密码
        /// </summary>
        public string SafeKey { get; set; }
        /// <summary>应用系统名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>备注
        /// </summary>
        public string ReMark { get; set; }
    }
}
