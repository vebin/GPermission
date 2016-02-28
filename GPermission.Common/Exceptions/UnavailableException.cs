using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Common
{
    public class UnavailableException : AbstractException
    {
        public UnavailableException()
        {

        }
        public UnavailableException(string message) : base(message)
        {
        }
    }
}
