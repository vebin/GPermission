using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure;
using GPermission.Commands.Accounts;
using GPermission.Domain.Accounts;
using GPermission.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.CommandHandlers
{
    /// <summary>账号相关命令处理
    /// </summary>
    [Component]
    public class AccountCommandHandler
        : ICommandHandler<CreateAccount>                                    //创建账号
        , ICommandHandler<ChangeAccount>                                    //删除账号
        , ICommandHandler<AddAppSystem>                                     //添加账号下的系统
        , ICommandHandler<RemoveAppSystem>                                  //移除账号下的系统
        , ICommandHandler<ResetAppSystem>                                   //重置账号下的系统
    {
        private ILockService _lockService;
        private AppSystemService _appSystemService;
        public AccountCommandHandler(ILockService lockService, AppSystemService appSystemService)
        {
            _lockService = lockService;
            _appSystemService = appSystemService;
        }
        /// <summary>创建账号
        /// </summary>
        public void Handle(ICommandContext context, CreateAccount command)
        {
            var info = new AccountInfo(command.AccountName, command.AccountPassword, command.AccountType, command.ReMark);
            context.Add(new Account(command.AggregateRootId, info));
        }

        /// <summary>删除账号
        /// </summary>
        public void Handle(ICommandContext context, ChangeAccount command)
        {
            context.Get<Account>(command.AggregateRootId).Change(command.UseFlag);
        }

        /// <summary>添加账号下的系统
        /// </summary>
        public void Handle(ICommandContext context, AddAppSystem command)
        {
            _lockService.ExecuteInLock(typeof(Account).Name, () =>
            {
                foreach (var appSystemId in command.AppSystemIds)
                {
                    _appSystemService.Exist(appSystemId);
                }
                context.Get<Account>(command.AggregateRootId).AddAppSystem(command.AppSystemIds);
            });
        }

        /// <summary>移除账号下的系统
        /// </summary>
        public void Handle(ICommandContext context, RemoveAppSystem command)
        {
            context.Get<Account>(command.AggregateRootId).RemoveAppSystem(command.AppSystemId);
        }

        /// <summary>重置账号下的系统
        /// </summary>
        public void Handle(ICommandContext context, ResetAppSystem command)
        {
            _lockService.ExecuteInLock(typeof(Account).Name, () =>
            {
                foreach (var appSystemId in command.AppSystemIds)
                {
                    _appSystemService.Exist(appSystemId);
                }
                context.Get<Account>(command.AggregateRootId).ResetAppSystem(command.AppSystemIds);
            });
        }
    }
}
