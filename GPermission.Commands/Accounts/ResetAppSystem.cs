using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Accounts
{
    /// <summary>重新设置账号下所有系统命令
    /// </summary>
    public class ResetAppSystem : Command<string>
    {
        public List<string> AppSystemIds { get; set; }

        public ResetAppSystem()
        {

        }
        public ResetAppSystem(string id, List<string> appSystemIds) : base(id)
        {
            AppSystemIds = appSystemIds;
        }
    }
}
