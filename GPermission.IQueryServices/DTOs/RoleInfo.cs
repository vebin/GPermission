namespace GPermission.IQueryServices.DTOs
{
    /// <summary>角色信息实体
    /// </summary>
    public class RoleInfo
    {
        /// <summary>角色Id
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>所属系统Id
        /// </summary>
        public string AppSystemId { get; set; }
        /// <summary>角色名
        /// </summary>
        public string Name { get; set; }
        /// <summary>角色代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>角色类型
        /// </summary>
        public string RoleType { get; set; }
        /// <summary>是否启用
        /// </summary>
        public int IsEnabled { get; set; }
        /// <summary>备注
        /// </summary>
        public string ReMark { get; set; }
    }
}
