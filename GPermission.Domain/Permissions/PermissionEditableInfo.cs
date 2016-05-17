using System;

namespace GPermission.Domain.Permissions
{
    /// <summary>权限修改实体
    /// </summary>
    public class PermissionEditableInfo
    {
        /// <summary>权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>权限类型
        /// </summary>
        public string PermissionType { get; set; }

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

        public PermissionEditableInfo(string name, string permissionType, string parentPermission = "",
            string permissionUrl = "", int sort = 0, string describe = "", string reMark = "")
        {
            Name = name;
            PermissionType = permissionType;
            ParentPermission = parentPermission;
            PermissionUrl = permissionUrl;
            Sort = sort;
            Describe = describe;
            ReMark = reMark;
        }
    }
}
