using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ECommon.Utilities;
using ENode.Commanding;
using GPermission.Admin.Extensions;
using GPermission.Admin.Models;
using GPermission.Commands.Permissions;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using GPermission.IQueryServices.DTOs;

namespace GPermission.Admin.Api
{
    public class PermissionController : BaseApiController
    {
        private readonly IPermissionQueryService _permissionQueryService;

        public PermissionController(ICommandService commandService, IPermissionQueryService permissionQueryService)
            : base(commandService)
        {
            _permissionQueryService = permissionQueryService;
        }

        // GET: api/Permission get highests permissions
        public IEnumerable<PermissionInfo> Get(string appSystemId)
        {
            return _permissionQueryService.FindHighests(appSystemId);
        }

        // GET: api/Permission/5
        public IEnumerable<PermissionInfo> Get(string appSystemId, string permissionType)
        {
            return _permissionQueryService.FindPermissionTypeHighests(appSystemId, permissionType);
        }

        // POST: api/Permission create permission
        public async Task<HandleResult> Post([FromBody]CreatePermissionDto dto)
        {
            var command = new CreatePermission(
                ObjectId.GenerateNewStringId(),
                dto.AppSystemId,
                ObjectId.GenerateNewStringId(), 
                dto.Name, 
                dto.PermissionType,
                dto.IsVisible, 
                dto.ParentPermission,
                dto.PermissionUrl,
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

        // PUT: api/Permission/5  Update permission
        public async Task<HandleResult> Put(string id, [FromBody]UpdatePermissionDto dto)
        {
            var command = new UpdatePermission(id,
                dto.Name,
                dto.PermissionType,
                dto.ParentPermission,
                dto.PermissionUrl,
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

        // DELETE: api/Permission/5
        public async Task<HandleResult> Delete(string id)
        {
            var command=new ChangePermission(id,(int)UseFlag.Disabled);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("删除成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }
    }
}
