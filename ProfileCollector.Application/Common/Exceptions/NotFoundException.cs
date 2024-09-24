using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public string ParamName { get; }

        public NotFoundException() : base()
        {
            ParamName = "Unknown";
        }

        public NotFoundException(string paramName, string message) : base(message)
        {
            ParamName = paramName;
        }
    }
}
