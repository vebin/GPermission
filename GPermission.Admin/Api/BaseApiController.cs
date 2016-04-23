using System.Threading.Tasks;
using System.Web.Http;
using ECommon.Extensions;
using ECommon.IO;
using ENode.Commanding;
using GPermission.Admin.Models;

namespace GPermission.Admin.Api
{
    public class BaseApiController : ApiController
    {
        private readonly ICommandService _commandService;

        public BaseApiController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        protected Task<AsyncTaskResult<CommandResult>> ExecuteCommandAsync(ICommand command,
            int millisecondsDelay = 5000)
        {
            return _commandService.ExecuteAsync(command, CommandReturnType.EventHandled).TimeoutAfter(millisecondsDelay);
        }

        protected Account GetAccount()
        {
            return new Account();
        }

        protected string AccountId
        {
            get { return GetAccount().AccountId; }
        }
    }
}
