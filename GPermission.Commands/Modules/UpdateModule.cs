﻿using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Modules
{
    /// <summary>更新模块命令
    /// </summary>
    public class UpdateModule:Command<string>
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
        /// <summary>全名称
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

        public UpdateModule(string id, string name, string parentModule, string moduleType,string verifyType,int isVisible, string linkUrl="", string assemblyName = "", string fullName = "",int sort=0,string describe="",string reMark="") : base(id)
        {
            Name = name;
            ParentModule = parentModule;
            ModuleType = moduleType;
            VerifyType = verifyType;
            IsVisible = isVisible;
            LinkUrl = linkUrl;
            AssemblyName = assemblyName;
            FullName = fullName;
            Sort = sort;
            Describe = describe;
            ReMark = reMark;
        }
    }
}
