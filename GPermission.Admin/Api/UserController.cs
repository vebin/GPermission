using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ENode.Commanding;
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
        public IEnumerable<UserInfo> Get(string appSystemId)
        {
            return _userQueryService.FindAllByAppSystemId(appSystemId);
        }




        // GET: api/User/5

        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User

        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5

        public void Delete(int id)
        {
        }
    }
}
