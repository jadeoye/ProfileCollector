using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Domain.Exceptions
{
    public class BusinessRuleException : Exception
    {
        public string ParamName { get; }

        public BusinessRuleException() : base()
        {
            ParamName = "Unknown";
        }

        public BusinessRuleException(string paramName, string message) : base(message)
        {
            ParamName = paramName;
        }
    }
}
