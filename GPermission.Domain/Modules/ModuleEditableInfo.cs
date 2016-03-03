using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>模块修改时实体
    /// </summary>
    public class ModuleEditableInfo
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
        /// <summary>链接地址
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>全名称
        /// </summary>
        public string AssemblyName { get; set; }
        /// <summary>全名称
        /// </summary>
        public string FullName { get; set; }
        
        public ModuleEditableInfo(string name,string parentModule,string moduleType,string linkUrl,string assemblyName="",string fullName="")
        {
            Name = name;
            ParentModule = parentModule;
            ModuleType = moduleType;
            LinkUrl = linkUrl;
            AssemblyName = assemblyName;
            FullName = fullName;
        }
    }
}
