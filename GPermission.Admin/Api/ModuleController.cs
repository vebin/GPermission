using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ECommon.Utilities;
using ENode.Commanding;
using GPermission.Admin.Extensions;
using GPermission.Admin.Models;
using GPermission.Commands.Modules;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using GPermission.IQueryServices.DTOs;

namespace GPermission.Admin.Api
{
    public class ModuleController : BaseApiController
    {
        private readonly IModuleQueryService _moduleQueryService;

        public ModuleController(ICommandService commandService, IModuleQueryService moduleQueryService)
            : base(commandService)
        {
            _moduleQueryService = moduleQueryService;
        }


        //GET: api/Module?appSystemId=xxxx  get highests modules.
        public IEnumerable<ModuleInfo> Get(string appSystemId)
        {
            return _moduleQueryService.FindHighests(appSystemId);
        }

        // GET: api/Module?appSystemId=xxx&moduleType=xxxx get highests modules by module type

        public IEnumerable<ModuleInfo> Get(string appSystemId, string moduleType)
        {
            return _moduleQueryService.FindModuleTypeHighests(appSystemId, moduleType);
        }


        // POST: api/Module  create module

        public async Task<HandleResult> Post([FromBody] CreateModuleDto dto)
        {
            var command = new CreateModule(
                ObjectId.GenerateNewStringId(),
                dto.AppSystemId,
                ObjectId.GenerateNewStringId(),
                dto.Name,
                dto.ModuleType,
                dto.VerifyType,
                dto.IsVisible,
                dto.ParentModule,
                dto.LinkUrl,
                dto.AssemblyName,
                dto.FullName,
                dto.Sort,
                dto.Describe,
                dto.ReMark);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("创建成功", command.Code);
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }

        // PUT: api/Module/5  update module

        public async Task<HandleResult> Put(string id, [FromBody]UpdateModuleDto dto)
        {
            var command = new UpdateModule(id,
                dto.Name,
                dto.ParentModule,
                dto.ModuleType,
                dto.VerifyType,
                dto.IsVisible,
                dto.LinkUrl,
                dto.AssemblyName,
                dto.FullName,
                dto.Sort,
                dto.Describe,
                dto.ReMark);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("更新成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }

        // DELETE: api/Module/5 delete module

        public async Task<HandleResult> Delete(string id)
        {
            var command = new ChangeModule(id, (int) UseFlag.Disabled);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("删除成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }
    }
}
