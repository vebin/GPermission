using GPermission.IQueryServices;
using GPermission.IQueryServices.DTOs;
using GUtils.Untility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GPermission.Api.Controllers
{
    public class AppSystemController : ApiController
    {
        private IAppSystemQueryService _appSystemQueryService;
        public AppSystemController(IAppSystemQueryService appSystemQueryService)
        {
            _appSystemQueryService = appSystemQueryService;
        }

        // GET: api/AppSystem 分页查询
        public IEnumerable<AppSystemInfo> Get()
        {
            string code = RequestUtils.GetString("Code");
            string name = RequestUtils.GetString("Name");
            string status = RequestUtils.GetString("Status");
            return _appSystemQueryService.Paging(code, name, status);
        }

        // GET: api/AppSystem/5
        public AppSystemInfo Get(string code)
        {
            code = StringUtils.NormalFilter(code);
            return _appSystemQueryService.FindByCode(code);
        }

        // POST: api/AppSystem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AppSystem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppSystem/5
        public void Delete(string code)
        {
            var appSystem = _appSystemQueryService.FindByCode(code);

        }
    }
}
