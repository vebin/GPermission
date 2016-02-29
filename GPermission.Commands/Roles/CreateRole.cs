using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Roles
{
    /// <summary>创建角色命令
    /// </summary>
    public class CreateRole : Command<string>
    {
        /// <summary>角色代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>所属系统Id
        /// </summary>
        public string AppSystemId { get; set; }
        /// <summary>角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>角色类型
        /// </summary>
        public string RoleType { get; set; }
        /// <summary>是否启用
        /// </summary>
        public int IsEnabled { get; set; }

        public string ReMark { get; set; }

        public CreateRole()
        {

        }

        public CreateRole(string id, string code, string appSystemId, string name, string roleType,int isEnabled, string reMark = "") : base(id)
        {
            Code = code;
            AppSystemId = appSystemId;
            Name = name;
            RoleType = roleType;
            IsEnabled = isEnabled;
            ReMark = reMark;
        }
    }
}
