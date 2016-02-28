using System;

namespace GPermission.Common
{
    public class RepeatException: AbstractException
    {
        public RepeatException():base()
        {

        }
        public RepeatException(string message) : base(message)
        {

        }
    }
}
