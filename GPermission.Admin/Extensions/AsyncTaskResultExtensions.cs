using ECommon.IO;
using ENode.Commanding;

namespace GPermission.Admin.Extensions
{
    public static class AsyncTaskResultExtensions
    {
        public static bool IsSuccess(this AsyncTaskResult<CommandResult> result)
        {
            if (result.Status != AsyncTaskStatus.Success || result.Data.Status == CommandStatus.Failed)
            {
                return false;
            }
            return true;
        }

        public static string GetErrorMessage(this AsyncTaskResult<CommandResult> result)
        {
            if (result.Status != AsyncTaskStatus.Success || result.Data.Status == CommandStatus.Failed)
            {
                if (result.ErrorMessage != null)
                {
                    return result.ErrorMessage;
                }
                return result.Data.Result;
            }
            return null;
        }

        
    }

    public class HandleResult
    {
        public int Success { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }


        public static HandleResult FromSuccess(string message,dynamic data=null)
        {
            return new HandleResult()
            {
                Success = 1,
                Message = message,
                Data = data
            };
        }

        public static HandleResult FromFail(string errorMessage, dynamic data = null)
        {
            return new HandleResult()
            {
                Success = -1,
                Message = errorMessage,
                Data = data
            };
        }
    }
}