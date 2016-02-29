using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Domain.Roles
{
    /// <summary>角色代码索引
    /// </summary>
    public class RoleCodeIndex
    {
        public string RoleId { get; set; }
        public string Code { get; set; }

        

        public RoleCodeIndex(string roleId,string code)
        {
            RoleId = roleId;
            Code = code;
        }
    }
}
