namespace GPermission.Admin.Models
{
    /// <summary>创建权限Dto
    /// </summary>
    public class CreatePermissionDto
    {
        /// <summary>所属系统Id
        /// </summary>
        public string AppSystemId { get; set; }
        /// <summary>权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>权限类型
        /// </summary>
        public string PermissionType { get; set; }
        /// <summary>是否可见
        /// </summary>
        public int IsVisible { get; set; }

        /// <summary>上级权限
        /// </summary>
        public string ParentPermission { get; set; }
        /// <summary>权限地址
        /// </summary>
        public string PermissionUrl { get; set; }
        /// <summary>排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>描述
        /// </summary>
        public string Describe { get; set; }
        public string ReMark { get; set; }
    }
}