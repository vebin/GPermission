namespace GPermission.Domain.Roles
{
    /// <summary>更新角色
    /// </summary>
    public class RoleEditableInfo
    {
        /// <summary>角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>角色类型
        /// </summary>
        public string RoleType { get; set; }

        /// <summary>备注
        ///  </summary>
        public string ReMark { get; set; }

        public RoleEditableInfo(string name, string roleType, string reMark = "")
        {
            Name = name;
            RoleType = roleType;
            ReMark = reMark;
        }
    }
}
