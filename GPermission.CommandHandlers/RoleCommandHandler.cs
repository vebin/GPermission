using ECommon.Components;
using ENode.Commanding;
using ENode.Infrastructure;
using GPermission.Commands.Roles;
using GPermission.Domain.Roles;
using GPermission.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.CommandHandlers
{
    /// <summary>角色相关命令处理
    /// </summary>
    [Component]
    public class RoleCommandHandler
        : ICommandHandler<CreateRole>                                     //创建角色
        , ICommandHandler<ChangeRole>                                     //删除角色
    {
        private readonly ILockService _lockService;
        private readonly RoleService _roleService;
        private readonly AppSystemService _appSystemService;
        public RoleCommandHandler(ILockService lockService,RoleService roleService,AppSystemService appSystemService)
        {
            _lockService = lockService;
            _roleService = roleService;
            _appSystemService = appSystemService;
        }

        /// <summary>创建角色
        /// </summary>
        public void Handle(ICommandContext context, CreateRole command)
        {
            _lockService.ExecuteInLock(typeof(Role).Name, () =>
            {
                _appSystemService.CheckExist(command.AppSystemId);
                var info = new RoleInfo(
                    command.Code,
                    command.AppSystemId, 
                    command.Name, 
                    command.RoleType, 
                    command.ReMark);
                context.Add(new Role(command.AggregateRootId, info, command.IsEnabled));
            });
        }


        /// <summary>删除角色
        /// </summary>
        public void Handle(ICommandContext context, ChangeRole command)
        {
            _lockService.ExecuteInLock(typeof(Role).Name, () =>
            {
                _roleService.DeleteRoleCodeIndex(command.AggregateRootId);
                context.Get<Role>(command.AggregateRootId).Change(command.UseFlag);
            });
        }
    }
}
