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
        , ICommandHandler<AttachUserRole>                                       //添加用户角色
        , ICommandHandler<DetachUserRole>                                       //移除用户角色
        , ICommandHandler<ResetUserRole>                                        //重置用具角色
        , ICommandHandler<LockedUser>                                           //锁定用户
        , ICommandHandler<UnLockedUser>                                         //解锁用户
        
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
        public void Handle(ICommandContext context, AttachUserRole command)
        {
            _lockService.ExecuteInLock(typeof(User).Name, () =>
            {
                foreach (var roleId in command.RoleIds)
                {
                    _roleService.IsEnabled(roleId);
                }
                context.Get<User>(command.AggregateRootId).AttachUserRole(command.RoleIds);
            });
        }

        /// <summary>移除用户角色
        /// </summary>
        public void Handle(ICommandContext context, DetachUserRole command)
        {
            context.Get<User>(command.AggregateRootId).DetachUserRole(command.RoleId);
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

        /// <summary>锁定用户
        /// </summary>
        public void Handle(ICommandContext context, LockedUser command)
        {
            context.Get<User>(command.AggregateRootId).Locked();
        }

        /// <summary>解锁用户
        /// </summary>
        public void Handle(ICommandContext context, UnLockedUser command)
        {
            context.Get<User>(command.AggregateRootId).Unlock();
        }
    }
}
