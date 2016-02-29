using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Users
{
    /// <summary>创建用户命令
    /// </summary>
    public class CreateUser:Command<string>
    {
        /// <summary>代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>系统Id
        /// </summary>
        public string AppSystemId { get; set; }
        /// <summary>用户名
        /// </summary>
        public string UserName { get; set; }

        public string ReMark { get; set; }

        public CreateUser()
        {

        }
        public CreateUser(string id, string code, string appSystemId, string userName, string reMark = "") : base(id)
        {
            Code = code;
            AppSystemId = appSystemId;
            UserName = userName;
            ReMark = reMark;
        }
    }
}
