using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Roles
{
    /// <summary>角色实体
    /// </summary>
    public class RoleInfo
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
        /// <summary>创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>备注
        /// </summary>
        public string ReMark { get; set; }

        public RoleInfo()
        {

        }

        public RoleInfo(string code,string appSystemId,string name,string roleType,string reMark="")
        {
            Code = code;
            AppSystemId = appSystemId;
            Name = name;
            RoleType = roleType;
            ReMark = reMark;
            CreateTime = DateTime.Now;
        }
    }
}
