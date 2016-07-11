using System.Collections.Generic;
using System.Web.Http;
using ENode.Commanding;

namespace GPermission.Admin.Controllers
{
    public class ModulePermissionController : BaseApiController
    {

        public ModulePermissionController(ICommandService commandService)
            : base(commandService)
        {

        }

        // GET: api/ModulePermission
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ModulePermission/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ModulePermission
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ModulePermission/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ModulePermission/5
        public void Delete(int id)
        {
        }

      
    }
}
