using GPermission.IQueryServices;
using GPermission.IQueryServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GPermission.Api.Controllers
{
    public class UserController : ApiController
    {
       
        private IUserQueryService _userQueryService;
        public UserController(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        //// GET: api/User
        public IEnumerable<UserInfo> Get()
        {
            string qppSystemCode = GUtils.Untility.RequestUtils.GetString("Code");
            
            //必须先获取是哪个账号,属于哪个系统
            string appSystemId = "";
            return _userQueryService.FindAll(appSystemId);
        }

        // GET: api/User/5
        public UserInfo Get(string userCode)
        {
            return _userQueryService.FindByCode("",userCode);
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
        public void Delete(string userCode)
        {

        }
    }
}
