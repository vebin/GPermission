using ENode.Commanding;

namespace GPermission.Commands.Modules
{
    /// <summary>解锁模块
    /// </summary>
    public class UnLockModule:Command<string>
    {
        public UnLockModule()
        {

        }

        public UnLockModule(string id) : base(id)
        {

        }
    }
}
