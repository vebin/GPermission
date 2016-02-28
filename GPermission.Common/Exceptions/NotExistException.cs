using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Common
{
    public class NotExistException: AbstractException
    {
        public NotExistException() : base()
        {
        }
        public NotExistException(string message) : base(message)
        {
        }
    }
}
