using ENode.Commanding;

namespace GPermission.Commands.Accounts
{
    /// <summary>创建账号命令
    /// </summary>
    public class CreateAccount : Command<string>
    {
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }
        public string AccountType { get; set; }
        public string ReMark { get; set; }

        public CreateAccount()
        {

        }

        public CreateAccount(string id, string accountName, string accountPassword, string accountType, string reMark = "") : base(id)
        {
            AccountName = accountName;
            AccountPassword = accountPassword;
            AccountType = accountType;
            ReMark = reMark;
        }
        
    }
}
