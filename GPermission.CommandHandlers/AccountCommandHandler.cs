using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure;
using GPermission.Commands.Accounts;
using GPermission.Domain.Accounts;
using GPermission.Domain.Services;

namespace GPermission.CommandHandlers
{
    /// <summary>账号相关命令处理
    /// </summary>
    [Component]
    public class AccountCommandHandler
        : ICommandHandler<CreateAccount>                                    //创建账号
        , ICommandHandler<ChangeAccount>                                    //删除账号
    {
        private readonly ILockService _lockService;
        private readonly AppSystemService _appSystemService;
        public AccountCommandHandler(ILockService lockService, AppSystemService appSystemService)
        {
            _lockService = lockService;
            _appSystemService = appSystemService;
        }

        /// <summary>创建账号
        /// </summary>
        public void Handle(ICommandContext context, CreateAccount command)
        {
            var info = new AccountInfo(
                command.AccountName,
                command.AccountPassword,
                command.AccountType,
                command.ReMark);
            context.Add(new Account(command.AggregateRootId, info));
        }

        /// <summary>删除账号
        /// </summary>
        public void Handle(ICommandContext context, ChangeAccount command)
        {
            context.Get<Account>(command.AggregateRootId).Change(command.UseFlag);
        }
    }
}
