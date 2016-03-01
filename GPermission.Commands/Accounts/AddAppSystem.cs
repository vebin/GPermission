using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Accounts
{
    /// <summary>添加账号下的系统命令
    /// </summary>
    public class AddAppSystem : Command<string>
    {
        public List<string> AppSystemIds { get; set; }

        public AddAppSystem()
        {

        }

        public AddAppSystem(string id,List<string> appSystemIds):base(id)
        {
            AppSystemIds = appSystemIds;
        }
    }
}
