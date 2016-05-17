using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPermission.Admin.Models
{
    /// <summary>更新模块Dto
    /// </summary>
    public class UpdateModuleDto
    {
        /// <summary>模块名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>上级模块
        /// </summary>
        public string ParentModule { get; set; }

        /// <summary>模块类型
        /// </summary>
        public string ModuleType { get; set; }

        /// <summary>验证方式
        /// </summary>
        public string VerifyType { get; set; }

        /// <summary>是否可见
        /// </summary>
        public int IsVisible { get; set; }

        /// <summary>链接地址
        /// </summary>
        public string LinkUrl { get; set; }

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