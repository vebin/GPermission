using ECommon.Components;
using ECommon.Extensions;
using ECommon.IO;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GPermission.Admin.Controllers
{
    public class BaseController : Controller
    {
        private ICommandService _commandService;
        public BaseController()
        {
            _commandService = ObjectContainer.Resolve<ICommandService>();
        }

        protected Task<AsyncTaskResult<CommandResult>> ExecuteCommandAsync(ICommand command, int millisecondsDelay = 5000)
        {
            return _commandService.ExecuteAsync(command, CommandReturnType.EventHandled).TimeoutAfter(millisecondsDelay);
        }
    }
}