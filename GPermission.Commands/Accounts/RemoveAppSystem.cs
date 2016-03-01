using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Accounts
{
    /// <summary>移除账号下系统命令
    /// </summary>
    public class RemoveAppSystem : Command<string>
    {
        public string AppSystemId { get; set; }

        public RemoveAppSystem()
        {

        }

        public RemoveAppSystem(string id, string appSystemId) : base(id)
        {
            AppSystemId = appSystemId;
        }
    }
}
