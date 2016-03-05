using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure;
using GPermission.Commands.Permissions;
using GPermission.Domain.Permissions;
using GPermission.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.CommandHandlers
{
    /// <summary>权限相关命令处理
    /// </summary>
    [Component]
    public class PermissionCommandHandler
        : ICommandHandler<CreatePermission>                                          //创建权限
        , ICommandHandler<UpdatePermission>                                          //更新权限
        , ICommandHandler<ChangePermission>                                          //删除权限
        , ICommandHandler<SetPermissionVisible>                                      //设置权限可见
        , ICommandHandler<SetPermissionInVisible>                                    //设置权限不可见
        , ICommandHandler<LockPermission>                                            //锁定权限
        , ICommandHandler<UnLockPermission>                                          //解锁权限
    {
        private ILockService _lockService;
        private PermissionService _permissionService;
        private AppSystemService _appSystemService;
        public PermissionCommandHandler(ILockService lockService,PermissionService permissionService, AppSystemService appSystemService)
        {
            _lockService = lockService;
            _permissionService = permissionService;
            _appSystemService = appSystemService;
        }
        /// <summary>创建权限
        /// </summary>
        public void Handle(ICommandContext context, CreatePermission command)
        {
            _lockService.ExecuteInLock(typeof(Permission).Name, () =>
            {
                _appSystemService.Exist(command.AppSystemId);
                _permissionService.Exist(command.ParentPermission);
                var info = new PermissionInfo(command.AppSystemId, command.Code, command.Name, command.PermissionType, command.ParentPermission, command.AssemblyName, command.FullName, command.PermissionUrl, command.Sort, command.ReMark);
                context.Add(new Permission(command.AggregateRootId, info, command.IsVisible));
            });
        }

        /// <summary>更新权限
        /// </summary>
        public void Handle(ICommandContext context, UpdatePermission command)
        {
            _lockService.ExecuteInLock(typeof(Permission).Name, () =>
            {
                _permissionService.Exist(command.ParentPermission);
                var info = new PermissionEditableInfo(command.Name, command.PermissionType, command.ParentPermission, command.AssemblyName, command.FullName, command.PermissionUrl, command.Sort, command.ReMark);
                context.Get<Permission>(command.AggregateRootId).Update(info);
            });

        }

        /// <summary>删除权限
        /// </summary>
        public void Handle(ICommandContext context, ChangePermission command)
        {
            context.Get<Permission>(command.AggregateRootId).Change(command.UseFlag);
        }

        /// <summary>设置权限可见
        /// </summary>
        public void Handle(ICommandContext context, SetPermissionVisible command)
        {
            context.Get<Permission>(command.AggregateRootId).SetVisible();
        }

        /// <summary>设置权限不可见
        /// </summary>
        public void Handle(ICommandContext context, SetPermissionInVisible command)
        {
            context.Get<Permission>(command.AggregateRootId).SetInVisible();
        }

        /// <summary>锁定权限
        /// </summary>
        public void Handle(ICommandContext context, LockPermission command)
        {
            context.Get<Permission>(command.AggregateRootId).Locked();
        }

        /// <summary>解锁权限
        /// </summary>
        public void Handle(ICommandContext context, UnLockPermission command)
        {
            context.Get<Permission>(command.AggregateRootId).UnLock();
        }
    }
}
