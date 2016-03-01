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
        , ICommandHandler<ChangeUser>                                           //删除用户
        , ICommandHandler<AddUserRole>                                          //添加用户角色
        , ICommandHandler<RemoveUserRole>                                       //移除用户角色
        , ICommandHandler<ResetUserRole>                                        //重置用具角色
    {
        private ILockService _lockService;
        private UserService _userService;
        private RoleService _roleService;
        private AppSystemService _appSystemService;
        public UserCommandHandler(ILockService lockService, UserService userService, RoleService roleService, AppSystemService appSystemService)
        {
            _lockService = lockService;
            _userService = userService;
            _roleService = roleService;
            _appSystemService = appSystemService;
        }

        /// <summary>创建用户
        /// </summary>
        public void Handle(ICommandContext context, CreateUser command)
        {
            _lockService.ExecuteInLock(typeof(User).Name, () =>
            {
                _appSystemService.Exist(command.AppSystemId);
                _userService.RegisterUserCodeIndex(command.AggregateRootId, command.Code);
                var info = new UserInfo(command.Code, command.AppSystemId, command.UserName, command.ReMark);
                context.Add(new User(command.AggregateRootId, info));
            });
        }

        /// <summary>删除用户
        /// </summary>
        public void Handle(ICommandContext context, ChangeUser command)
        {
            _lockService.ExecuteInLock(typeof(User).Name, () =>
            {
                _userService.DeleteUserCodeIndex(command.AggregateRootId);
                context.Get<User>(command.AggregateRootId).Change(command.UseFlag);
            });
        }

        /// <summary>添加用户角色
        /// </summary>
        public void Handle(ICommandContext context, AddUserRole command)
        {
            _lockService.ExecuteInLock(typeof(User).Name, () =>
            {
                foreach (var roleId in command.RoleIds)
                {
                    _roleService.IsEnabled(roleId);
                }
                context.Get<User>(command.AggregateRootId).AddUserRole(command.RoleIds);
            });
        }

        /// <summary>移除用户角色
        /// </summary>
        public void Handle(ICommandContext context, RemoveUserRole command)
        {
            context.Get<User>(command.AggregateRootId).RemoveUserRole(command.RoleId);
        }

        /// <summary>重置用户角色
        /// </summary>
        public void Handle(ICommandContext context, ResetUserRole command)
        {
            _lockService.ExecuteInLock(typeof(User).Name, () =>
            {
                foreach (var roleId in command.RoleIds)
                {
                    _roleService.IsEnabled(roleId);
                }
                context.Get<User>(command.AggregateRootId).ResetUserRole(command.RoleIds);
            });
        }
    }
}
