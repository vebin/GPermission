using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Commands.Permissions
{
    /// <summary>设置权限可见
    /// </summary>
    public class SetPermissionVisible : Command<string>
    {
        public SetPermissionVisible()
        {

        }

        public SetPermissionVisible(string id) : base(id)
        {

        }
    }
}
