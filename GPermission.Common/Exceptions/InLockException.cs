using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Common
{
    public class InLockException: AbstractException
    {
        public InLockException()
        {

        }

        public InLockException(string message) : base(message)
        {

        }
    }
}
