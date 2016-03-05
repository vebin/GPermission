using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Permissions
{
    /// <summary>删除权限命令
    /// </summary>
    public class ChangePermission:Command<string>
    {
        public int UseFlag { get; set; }

        public ChangePermission()
        {

        }

        public ChangePermission(string id, int useFlag) : base(id)
        {
            UseFlag = useFlag;
        }
    }
}
