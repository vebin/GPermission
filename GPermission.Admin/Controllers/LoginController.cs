using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPermission.Admin.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>登录页面
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}