using ECommon.Utilities;
using ENode.Commanding;

namespace GPermission.Commands.AppSystems
{
    /// <summary>生成新密钥
    /// </summary>
    public class UpdateSafeKey : Command<string>
    {
        public string SafeKey { get; set; }

        public UpdateSafeKey()
        {

        }

        public UpdateSafeKey(string id) : base(id)
        {
            SafeKey = ObjectId.GenerateNewStringId();
        }
    }
}
