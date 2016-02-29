using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Users
{
    /// <summary>删除用户命令
    /// </summary>
    public class ChangeUser : Command<string>
    {
        public int UseFlag { get; set; }

        public ChangeUser()
        {

        }
        public ChangeUser(string id, int useFlag) : base(id)
        {
            UseFlag = useFlag;
        }
    }
}
