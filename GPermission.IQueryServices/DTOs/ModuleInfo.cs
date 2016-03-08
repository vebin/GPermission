using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.IQueryServices.DTOs
{
    /// <summary>模块信息实体
    /// </summary>
    public class ModuleInfo
    {
        /// <summary>模块Id
        /// </summary>
        public string ModuleId { get; set; }
        /// <summary>所属系统Id
        /// </summary>
        public string AppSystemId { get; set; }
        /// <summary>代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>模块类型
        /// </summary>
        public string ModuleType { get; set; }
        /// <summary>上级模块
        /// </summary>
        public string ParentModule { get; set; }
        /// <summary>链接地址
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>程序集名称
        /// </summary>
        public string AssemblyName { get; set; }
        /// <summary>全名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>是否为叶子节点
        /// </summary>
        public int IsLeaf { get; set; }
        /// <summary>模块验证类型
        /// </summary>
        public string VerifyType { get; set; }
        /// <summary>是否可见
        /// </summary>
        public int IsVisible { get; set; }
        /// <summary>排序
        /// </summary>
        public int Sort { get; set; }
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
