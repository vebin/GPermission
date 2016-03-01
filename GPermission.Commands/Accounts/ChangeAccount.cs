using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Accounts
{
    /// <summary>删除账号命令
    /// </summary>
    public class ChangeAccount:Command<string>
    {
        public int UseFlag { get; set; }

        public ChangeAccount()
        {

        }

        public ChangeAccount(string id, int useFlag) : base(id)
        {
            UseFlag = useFlag;
        }
    }
}
