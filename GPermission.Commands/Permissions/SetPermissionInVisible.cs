using ENode.Commanding;

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
