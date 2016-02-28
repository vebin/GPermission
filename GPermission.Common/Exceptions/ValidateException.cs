using System;

namespace GPermission.Common
{
    public class ValidateException: AbstractException
    {
        public ValidateException() : base()
        {
        }
        public ValidateException(string message) : base(message)
        {
        }
    }
}
