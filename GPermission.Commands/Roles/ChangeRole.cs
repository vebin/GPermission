using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Roles
{
    /// <summary>删除角色命令
    /// </summary>
    public class ChangeRole : Command<string>
    {
        public int UseFlag { get; set; }

        public ChangeRole()
        {

        }

        public ChangeRole(string id, int useFlag) : base(id)
        {
            UseFlag = useFlag;
        }
    }
}
