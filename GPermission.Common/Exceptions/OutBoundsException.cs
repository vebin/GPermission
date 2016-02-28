using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Common
{
    public class OutBoundsException : AbstractException
    {
        public OutBoundsException() : base()
        {

        }
        public OutBoundsException(string message) : base(message)
        {

        }
    }
}
