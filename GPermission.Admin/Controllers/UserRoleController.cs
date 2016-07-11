using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ENode.Commanding;
using GPermission.Admin.Extensions;
using GPermission.Commands.Users;
using GPermission.IQueryServices;
using GPermission.IQueryServices.DTOs;

namespace GPermission.Admin.Controllers
{
    public class UserRoleController : BaseApiController
    {
        private readonly IRoleQueryService _roleQueryService;
        public UserRoleController(ICommandService commandService, IRoleQueryService roleQueryService)
            : base(commandService)
        {
            _roleQueryService = roleQueryService;
        }


        // GET: api/UserRole
        public IEnumerable<RoleInfo> Get(string userId)
        {
            return _roleQueryService.FindUserRole(userId);
        }

        // GET: api/UserRole/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserRole  attach user role,id is userId
        public async Task<HandleResult> Post(string id, [FromBody] List<string> roleIds)
        {
            var command = new AttachUserRole(id, roleIds);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("设置成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }



        // PUT: api/UserRole/5 reset user role, id is userId
        public async Task<HandleResult> Put(string id, [FromBody] List<string> roleIds)
        {
            var command = new ResetUserRole(id, roleIds);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("设置成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }

        // DELETE: api/UserRole/5  detach a userRole, id is userId
        public async Task<HandleResult> Delete(string id, string roleId)
        {
            var command = new DetachUserRole(id, roleId);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("移除成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }



    }
}
