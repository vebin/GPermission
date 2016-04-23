namespace GPermission.IQueryServices.Dtos
{
    /// <summary>权限信息实体
    /// </summary>
    public class PermissionInfo
    {
        /// <summary>权限Id
        /// </summary>
        public string PermissionId { get; set; }
        /// <summary>所属系统Id
        /// </summary>
        public string AppSystemId { get; set; }
        /// <summary>权限代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>权限类型
        /// </summary>
        public string PermissionType { get; set; }
        /// <summary>程序集名
        /// </summary>
        public string AssemblyName { get; set; }
        /// <summary>类的全名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>权限地址
        /// </summary>
        public string PermissionUrl { get; set; }
        /// <summary>排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>是否可见
        /// </summary>
        public int IsVisible { get; set; }
        /// <summary>状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>备注
        /// </summary>
        public string ReMark { get; set; }
    }
}
