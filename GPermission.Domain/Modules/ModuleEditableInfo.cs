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
        /// <summary>模块类型
        /// </summary>
        public string ModuleType { get; set; }
        /// <summary>上级模块
        /// </summary>
        public string ParentModule { get; set; }
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

        public ModuleEditableInfo(string name, string moduleType, string parentModule, string linkUrl, int sort = 0,
            string describe = "", string reMark = "")
        {
            Name = name;
            ParentModule = parentModule;
            ModuleType = moduleType;
            LinkUrl = linkUrl;
            Sort = sort;
            Describe = describe;
            ReMark = reMark;
        }
    }
}
