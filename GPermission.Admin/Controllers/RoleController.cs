using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ECommon.Utilities;
using ENode.Commanding;
using GPermission.Admin.Extensions;
using GPermission.Admin.Models;
using GPermission.Commands.Roles;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using GPermission.IQueryServices.DTOs;

namespace GPermission.Admin.Controllers
{
    public class RoleController : BaseApiController
    {
        private readonly IRoleQueryService _roleQueryService;
        public RoleController(ICommandService commandService,IRoleQueryService roleQueryService) : base(commandService)
        {
            _roleQueryService = roleQueryService;
        }


        // GET: api/Role?appSystemId=xxxxxxxxx
        public IEnumerable<RoleInfo> Get(string appSystemId)
        {
            return _roleQueryService.FindAll(appSystemId);
        }

        //POST: api/Role 创建角色
        public async Task<HandleResult> Post([FromBody] CreateRoleDto dto)
        {
            var command = new CreateRole(
                ObjectId.GenerateNewStringId(),
                ObjectId.GenerateNewStringId(),
                dto.AppSystemId,
                dto.Name,
                dto.RoleType,
                dto.IsEnabled,
                dto.ReMark);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("创建成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }
        // PUT: api/AppSystem/5
        public async Task<HandleResult> Put(string id, [FromBody] UpdateRole dto)
        {
            var command = new UpdateRole(
                id,
                dto.Name,
                dto.RoleType,
                dto.IsEnabled,
                dto.ReMark);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("更新成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }

        // DELETE: api/AppSystem/5
        public async Task<HandleResult> Delete(string id)
        {
            var useFlag = (int) UseFlag.Disabled;
            var command = new ChangeRole(id, useFlag);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("删除成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }

    }
}
