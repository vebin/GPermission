using GPermission.IQueryServices;
using System.Web.Mvc;

namespace GPermission.Admin.Controllers
{
    public class LoginController : BaseController
    {
        private IAccountQueryService _accountQueryService;

        public LoginController(IAccountQueryService accountQueryService)
        {
            _accountQueryService = accountQueryService;
        }

        //private Task<AsyncTaskResult<CommandResult>> ExecuteCommandAsync(ICommand command, int millisecondsDelay = 5000)
        //{
        //    return _commandService.ExecuteAsync(command, CommandReturnType.EventHandled).TimeoutAfter(millisecondsDelay);
        //}

        /// <summary>登录页面
        /// </summary>
        [HttpGet]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>登陆提交
        /// </summary>
        //[HttpPost]
        //public async Task<ActionResult> LoginPost()
        //{
            
        //}


    }
}