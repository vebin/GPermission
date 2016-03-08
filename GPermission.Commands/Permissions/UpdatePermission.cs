using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Permissions
{
    /// <summary>更新权限命令
    /// </summary>
    public class UpdatePermission : Command<string>
    {
        /// <summary>权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>权限类型
        /// </summary>
        public string PermissionType { get; set; }

        /// <summary>上级权限
        /// </summary>
        public string ParentPermission { get; set; }
        /// <summary>程序集名称
        /// </summary>
        public string AssemblyName { get; set; }
        /// <summary>全名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>权限地址
        /// </summary>
        public string PermissionUrl { get; set; }
        /// <summary>排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>描述
        /// </summary>
        public string Describe { get; set; }

        public string ReMark { get; set; }
        public UpdatePermission(string name, string permissionType, string parentPermission = "", string assemblyName = "", string fullName = "", string permissionUrl = "", int sort = 0,string describe="", string reMark = "")
        {
            Name = name;
            PermissionType = permissionType;
            ParentPermission = parentPermission;
            AssemblyName = assemblyName;
            FullName = fullName;
            PermissionUrl = permissionUrl;
            Sort = sort;
            Describe = describe;
            ReMark = reMark;
        }
    }
}
