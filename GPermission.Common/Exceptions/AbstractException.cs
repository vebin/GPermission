using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Common
{
    public abstract class AbstractException : Exception
    {
        public AbstractException() : base()
        {

        }
        public AbstractException(string message) : base(message)
        {
        }
    }
}
