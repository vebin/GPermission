using ENode.Commanding;

namespace GPermission.Commands.Accounts
{
    /// <summary>删除账号命令
    /// </summary>
    public class ChangeAccount:Command<string>
    {
        public int UseFlag { get; set; }

        public ChangeAccount()
        {

        }

        public ChangeAccount(string id, int useFlag) : base(id)
        {
            UseFlag = useFlag;
        }
    }
}
