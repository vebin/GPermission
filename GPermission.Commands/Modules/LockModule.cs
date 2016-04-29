using ENode.Commanding;

namespace GPermission.Commands.Modules
{
    /// <summary>锁定模块命令
    /// </summary>
    public class LockModule:Command<string>
    {
        public LockModule()
        {

        }

        public LockModule(string id):base(id)
        {

        }
    }
}
