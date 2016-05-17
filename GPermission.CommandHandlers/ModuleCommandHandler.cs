using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure;
using GPermission.Commands.Modules;
using GPermission.Domain.Modules;
using GPermission.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.CommandHandlers
{
    /// <summary>模块相关命令处理
    /// </summary>
    [Component]
    public class ModuleCommandHandler
        : ICommandHandler<CreateModule>                                         //创建模块
        , ICommandHandler<UpdateModule>                                         //更新模块
        , ICommandHandler<ChangeModule>                                         //删除模块
        , ICommandHandler<SetModuleVisible>                                     //设置模块可见
        , ICommandHandler<SetModuleInVisible>                                   //设置模块不可见
        , ICommandHandler<LockModule>                                           //锁定模块
        , ICommandHandler<UnLockModule>                                         //解锁模块
        , ICommandHandler<SetModuleLeaf>                                        //设置模块是否叶子节点
        , ICommandHandler<AttachModulePermission>                               //添加模块权限
        , ICommandHandler<DetachModulePermission>                               //移除模块权限
        , ICommandHandler<UpdateModulePermission>                               //更新模块权限
    {
        private readonly ILockService _lockService;
        private readonly ModuleService _moduleService;
        private readonly PermissionService _permissionService;
        private readonly AppSystemService _appSystemService;

        public ModuleCommandHandler(ILockService lockService, ModuleService moduleService,
            PermissionService permissionService, AppSystemService appSystemService)
        {
            _lockService = lockService;
            _moduleService = moduleService;
            _permissionService = permissionService;
            _appSystemService = appSystemService;
        }

        /// <summary>创建模块
        /// </summary>
        public void Handle(ICommandContext context, CreateModule command)
        {
            _lockService.ExecuteInLock(typeof (Module).Name, () =>
            {
                _moduleService.Exist(command.ParentModule);
                _appSystemService.CheckExist(command.AppSystemId);
                var info = new ModuleInfo(
                    command.AppSystemId,
                    command.Code,
                    command.Name,
                    command.ModuleType,
                    command.ParentModule,
                    command.LinkUrl,
                    command.Sort,
                    command.Describe,
                    command.ReMark);
                context.Add(new Module(command.AggregateRootId, info, command.VerifyType, command.IsVisible));
            });
        }

        /// <summary>更新模块
        /// </summary>
        public void Handle(ICommandContext context, UpdateModule command)
        {
            _lockService.ExecuteInLock(typeof (Module).Name, () =>
            {
                _moduleService.Exist(command.ParentModule);
                var info = new ModuleEditableInfo(
                    command.Name,
                    command.ParentModule,
                    command.ModuleType,
                    command.LinkUrl,
                    command.Sort,
                    command.Describe,
                    command.ReMark);
                context.Get<Module>(command.AggregateRootId).Update(info, command.VerifyType, command.IsVisible);
            });
        }

        /// <summary>删除模块
        /// </summary>
        public void Handle(ICommandContext context, ChangeModule command)
        {
            context.Get<Module>(command.AggregateRootId).Change(command.UseFlag);
        }

        /// <summary>设置模块可见
        /// </summary>
        public void Handle(ICommandContext context, SetModuleVisible command)
        {
            context.Get<Module>(command.AggregateRootId).SetVisible();
        }

        /// <summary>设置模块不可见
        /// </summary>
        public void Handle(ICommandContext context, SetModuleInVisible command)
        {
            context.Get<Module>(command.AggregateRootId).SetInVisible();
        }

        /// <summary>锁定模块
        /// </summary>
        public void Handle(ICommandContext context, LockModule command)
        {
            context.Get<Module>(command.AggregateRootId).Locked();
        }

        /// <summary>解锁模块
        /// </summary>
        public void Handle(ICommandContext context, UnLockModule command)
        {
            context.Get<Module>(command.AggregateRootId).UnLock();
        }

        /// <summary>设置模块是否叶子节点
        /// </summary>
        public void Handle(ICommandContext context, SetModuleLeaf command)
        {
            context.Get<Module>(command.AggregateRootId).SetLeaf(command.IsLeaf);
        }

        /// <summary>添加模块权限
        /// </summary>
        public void Handle(ICommandContext context, AttachModulePermission command)
        {
            _lockService.ExecuteInLock(typeof(Module).Name, () =>
            {
                foreach (var permission in command.Permissions)
                {
                    _permissionService.Exist(permission.Value);
                }
                context.Get<Module>(command.AggregateRootId).AttachPermission(command.Permissions);
            });
        }

        /// <summary>移除模块权限
        /// </summary>
        public void Handle(ICommandContext context, DetachModulePermission command)
        {
            context.Get<Module>(command.AggregateRootId).DetachPermission(command.ModulePermissionId);
        }

        /// <summary>更新模块权限
        /// </summary>
        public void Handle(ICommandContext context, UpdateModulePermission command)
        {
            _lockService.ExecuteInLock(typeof(Module).Name, () =>
            {
                foreach (var permission in command.Permissions)
                {
                    _permissionService.Exist(permission.Value);
                }
                context.Get<Module>(command.AggregateRootId).UpdateAttachPermission(command.Permissions);
            });
        }
    }
}
