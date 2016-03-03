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
    {
        private ILockService _lockService;
        private ModuleService _moduleService;
        private AppSystemService _appSystemService;
        public ModuleCommandHandler(ILockService lockService, ModuleService moduleService,AppSystemService appSystemService)
        {
            _lockService = lockService;
            _moduleService = moduleService;
            _appSystemService = appSystemService;
        }

        /// <summary>创建模块
        /// </summary>
        public void Handle(ICommandContext context, CreateModule command)
        {
            _lockService.ExecuteInLock(typeof(Module).Name, () =>
            {
                _moduleService.Exist(command.ParentModule);
                _appSystemService.Exist(command.AppSystemId);
                var info = new ModuleInfo(command.AppSystemId, command.Code, command.Name, command.ModuleType, command.ParentModule, command.LinkUrl, command.AssemblyName, command.FullName, command.Sort, command.ReMark);
                context.Add(new Module(command.AggregateRootId, info, command.VerifyType, command.IsVisible));
            });
        }

        /// <summary>更新模块
        /// </summary>
        public void Handle(ICommandContext context, UpdateModule command)
        {
            _lockService.ExecuteInLock(typeof(Module).Name, () =>
            {
                _moduleService.Exist(command.ParentModule);
                //var info = new ModuleEditableInfo(command.Name, command.ParentModule, command.ModuleType, command.LinkUrl, command.AssemblyName, command.FullName);
                //context.Get<Module>(command.AggregateRootId).Update(info,command)
            });
        }
    }
}
