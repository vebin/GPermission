using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure;
using GPermission.Commands.Users;
using GPermission.Domain.Services;
using GPermission.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.CommandHandlers
{
    /// <summary>用户相关命令处理
    /// </summary>
    [Component]
    public class UserCommandHandler
        : ICommandHandler<CreateUser>                                           //创建用户
    {
        private ILockService _lockService;
        private UserService _userService;
        private AppSystemService _appSystemService;
        public UserCommandHandler(ILockService lockService, UserService userService,AppSystemService appSystemService)
        {
            _lockService = lockService;
            _userService = userService;
            _appSystemService = appSystemService;
        }

        /// <summary>创建用户
        /// </summary>
        public void Handle(ICommandContext context, CreateUser command)
        {
            _lockService.ExecuteInLock(typeof(User).Name, () =>
            {
                var info = new UserInfo(command.Code, command.AppSystemId, command.UserName, command.ReMark);
                context.Add(new User(command.AggregateRootId, info));
            });
        }
    }
}
