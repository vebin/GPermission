using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure;
using GPermission.Commands.AppSystems;
using GPermission.Domain.AppSystems;
using GPermission.Domain.Services;

namespace GPermission.CommandHandlers
{
    /// <summary>应用系统命令处理
    /// </summary>
    [Component]
    public class AppSystemCommandHandler
        : ICommandHandler<CreateAppSystem>                                                        //创建应用系统
        , ICommandHandler<ChangeAppSystem>                                                        //删除应用系统
        , ICommandHandler<UpdateSafeKey>                                                          //更新密钥
        , ICommandHandler<UpdateAppSystem>                                                        //更新应用信息
    {
        private readonly ILockService _lockService;
        private readonly AccountService _accountService;

        public AppSystemCommandHandler(ILockService lockService, AccountService accountService)
        {
            _lockService = lockService;
            _accountService = accountService;
        }

        /// <summary>创建应用系统
        /// </summary>
        public void Handle(ICommandContext context, CreateAppSystem command)
        {
            _lockService.ExecuteInLock(typeof (AppSystem).Name, () =>
            {
                _accountService.CheckExist(command.AccountId);
                var info = new AppSystemInfo(
                    command.Code,
                    command.Name,
                    command.AccountId,
                    command.ReMark);
                var appSystem = new AppSystem(
                    command.AggregateRootId,
                    info,
                    command.SafeKey);
                context.Add(appSystem);
            });

        }

        /// <summary>删除应用系统
        /// </summary>
        public void Handle(ICommandContext context, ChangeAppSystem command)
        {
            context.Get<AppSystem>(command.AggregateRootId).Change(command.UseFlag);
        }

        /// <summary>更新密钥
        /// </summary>
        public void Handle(ICommandContext context, UpdateSafeKey command)
        {
            context.Get<AppSystem>(command.AggregateRootId).UpdateSafeKey(command.SafeKey);
        }

        /// <summary>更新应用信息
        /// </summary>
        public void Handle(ICommandContext context, UpdateAppSystem command)
        {
            var info = new AppSystemEditableInfo(command.Name, command.ReMark);
            context.Get<AppSystem>(command.AggregateRootId).Update(info);
        }
    }
}
