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
        public string AppSystemId { get; set; }
        public int UseFlag { get; set; }

        public ChangeRole()
        {

        }

        public ChangeRole(string id,string appSystemId, int useFlag) : base(id)
        {
            AppSystemId = appSystemId;
            UseFlag = useFlag;
        }
    }
}
