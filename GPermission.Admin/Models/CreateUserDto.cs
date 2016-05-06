namespace GPermission.Admin.Models
{
    /// <summary>创建用户
    /// </summary>
    public class CreateUserDto
    {
        /// <summary>所属应用系统Id
        /// </summary>
        public string AppSystemId { get; set; }
        /// <summary>用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>备注
        /// </summary>
        public string ReMark { get; set; }
    }
}