using ENode.Commanding;

namespace GPermission.Commands.Modules
{
    /// <summary>设置模块不可见命令
    /// </summary>
    public class SetModuleInVisible : Command<string>
    {
        public SetModuleInVisible()
        {

        }

        public SetModuleInVisible(string id) : base(id)
        {

        }
    }
}
