using GPermission.IQueryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        /// <summary>登录页面
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}