using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Modules
{
    /// <summary>模块实体
    /// </summary>
    public class ModuleInfo
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
        public ModuleInfo(string appSystemId, string code, string name, string moduleType, string parentModule="", string linkUrl="", string assemblyName="", string fullName = "",int sort=0,string describe="",string reMark="")
        {
            AppSystemId = appSystemId;
            Code = code;
            Name = name;
            ModuleType = moduleType;
            ParentModule = parentModule;
            LinkUrl = linkUrl;
            AssemblyName = assemblyName;
            FullName = fullName;
            Sort = sort;
            Describe = describe;
            ReMark = reMark;
        }
    }
}
