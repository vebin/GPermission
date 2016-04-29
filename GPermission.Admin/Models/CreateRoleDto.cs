using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPermission.Admin.Models
{
    /// <summary>创建角色Dto
    /// </summary>
    public class CreateRoleDto
    {
        /// <summary>所属应用系统Id
        /// </summary>
        public string AppSystemId { get; set; }

        /// <summary>角色名
        /// </summary>
        public string Name { get; set; }

        /// <summary>角色类型
        /// </summary>
        public string RoleType { get; set; }
        /// <summary>是否开启
        /// </summary>
        public int IsEnabled { get; set; }
        /// <summary>备注
        /// </summary>
        public string ReMark { get; set; }
    }
}