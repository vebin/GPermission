namespace GPermission.Domain.Permissions
{
    /// <summary>权限实体
    /// </summary>
    public class PermissionInfo
    {
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
        public string Descrbie { get; set; }

        public string ReMark { get; set; }

        public PermissionInfo(string appSystemId, string code, string name, string permissionType,
            string parentPermission = "", string permissionUrl = "", int sort = 0, string describe = "",
            string reMark = "")
        {
            AppSystemId = appSystemId;
            Code = code;
            Name = name;
            PermissionType = permissionType;
            ParentPermission = parentPermission;
            PermissionUrl = permissionUrl;
            Sort = sort;
            Descrbie = describe;
            ReMark = reMark;
        }
    }
}
