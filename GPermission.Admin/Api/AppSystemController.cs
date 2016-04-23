using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ECommon.Utilities;
using ENode.Commanding;
using GPermission.Admin.Extensions;
using GPermission.Admin.Models;
using GPermission.Commands.AppSystems;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using GPermission.IQueryServices.Dtos;

namespace GPermission.Admin.Api
{
    public class AppSystemController : BaseApiController
    {
        private readonly IAppSystemQueryService _appSystemQueryService;

        public AppSystemController(ICommandService commandService, IAppSystemQueryService appSystemQueryService)
            : base(commandService)
        {
            _appSystemQueryService = appSystemQueryService;
        }

        // GET: api/AppSystem
        public IEnumerable<AppSystemInfo> Get()
        {
            return new AppSystemInfo[] {};
        }

        // GET: api/AppSystem/5
        public AppSystemInfo Get(string code)
        {
            return _appSystemQueryService.FindByCode(code);
        }

        // POST: api/AppSystem
        public async Task<HandleResult> Post([FromBody] CreateAppSystemDto dto)
        {
            var command = new CreateAppSystem(
                ObjectId.GenerateNewStringId(),
                GetAccount().AccountId,
                dto.Name,
                dto.ReMark);
            var result =await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("创建成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }

        // PUT: api/AppSystem/5
        public async Task<HandleResult> Put(string id, [FromBody] UpdateAppSystemDto dto)
        {
            var command = new UpdateAppSystem(id, dto.Name, dto.ReMark);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("更新成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }

        //更新密钥
        public async Task<HandleResult> Put(string id)
        {
            var command = new UpdateSafeKey(id);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("密钥已更新");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }


        // DELETE: api/AppSystem/5
        public async Task<HandleResult> Delete(string id)
        {
            var useFlag = (int) UseFlag.Disabled;
            var command = new ChangeAppSystem(id, useFlag);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("删除成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }
    }
}
