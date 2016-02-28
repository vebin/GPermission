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
        /// <summary>角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public RoleInfo()
        {

        }

        public RoleInfo(string code,string name)
        {
            Code = code;
            Name = name;
        }
    }
}
