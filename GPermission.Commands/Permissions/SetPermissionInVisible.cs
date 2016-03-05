using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Permissions
{
    /// <summary>设置权限不可见命令
    /// </summary>
    public class SetPermissionInVisible:Command<string>
    {
        public SetPermissionInVisible()
        {

        }

        public SetPermissionInVisible(string id):base(id)
        {
            
        }
    }
}
