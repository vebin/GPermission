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
using GPermission.Commands.Users;
using GPermission.Common.Enums;
using GPermission.IQueryServices;
using GPermission.IQueryServices.DTOs;

namespace GPermission.Admin.Api
{
    public class UserController : BaseApiController
    {
        private readonly IUserQueryService _userQueryService;

        public UserController(ICommandService commandService, IUserQueryService userQueryService) : base(commandService)
        {
            _userQueryService = userQueryService;
        }

        // GET: api/User

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET: api/User?appSystemId=3
        public IEnumerable<UserInfo> Get2(string appSystemId)
        {
            return _userQueryService.FindAllByAppSystemId(appSystemId);
        }


        // POST: api/User

        public async Task<HandleResult> Post([FromBody] CreateUserDto dto)
        {
            var command = new CreateUser(
                ObjectId.GenerateNewStringId(),
                ObjectId.GenerateNewStringId(),
                dto.AppSystemId,
                dto.UserName,
                dto.ReMark);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("创建成功", command.Code);
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }

        // PUT: api/User/5

        //public async Task<HandleResult> Put(string id, [FromBody] string status)
        //{
        //    ICommand command;
        //    if(status==UserStatus.Normal.ToString())
        //      command = new LockedUser(id);
        //    var result = await ExecuteCommandAsync(command);
        //    if (result.IsSuccess())
        //    {
        //        return HandleResult.FromSuccess("锁定成功");
        //    }
        //    return HandleResult.FromFail(result.GetErrorMessage());
        //}

        // DELETE: api/User/5

        public async Task<HandleResult> Delete(string id)
        {
            var command = new ChangeUser(id, (int) UseFlag.Useable);
            var result = await ExecuteCommandAsync(command);
            if (result.IsSuccess())
            {
                return HandleResult.FromSuccess("删除成功");
            }
            return HandleResult.FromFail(result.GetErrorMessage());
        }
    }
}
