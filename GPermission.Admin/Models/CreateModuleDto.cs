namespace GPermission.Admin.Models
{
    /// <summary>创建模块Dto
    /// </summary>
    public class CreateModuleDto
    {
        /// <summary>所属系统Id
        /// </summary>
        public string AppSystemId { get; set; }

        /// <summary>模块代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>模块名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>模块类型
        /// </summary>
        public string ModuleType { get; set; }

        /// <summary>验证类型
        /// </summary>
        public string VerifyType { get; set; }

        /// <summary>是否可见
        /// </summary>
        public int IsVisible { get; set; }

        /// <summary>上级模块
        /// </summary>
        public string ParentModule { get; set; }

        /// <summary>链接地址
        /// </summary>
        public string LinkUrl { get; set; }

        /// <summary>类的全名称
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>全名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>备注
        /// </summary>
        public string ReMark { get; set; }

    }
}