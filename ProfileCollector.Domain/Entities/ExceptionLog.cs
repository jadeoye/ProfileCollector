using CSharpFunctionalExtensions;
using ProfileCollector.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Domain.Entities
{
    public class ExceptionLog : Entity<string>, IAggregateRoot
    {
        public string Message { get; private set; }
        public string StackTrace { get; private set; }
        public DateTime OccurredAt { get; private set; }
        public string Path { get; private set; }
        public string Method { get; private set; }

        private ExceptionLog()
        {
        }

        private ExceptionLog(string message, string stackTrace, DateTime occurredAt, string path, string method)
        {
            Message = message;
            StackTrace = stackTrace;
            OccurredAt = occurredAt;
            Path = path;
            Method = method;
        }

        public static ExceptionLog Create(string message, string stackTrace, DateTime occurredAt, string path, string method)
        {
            return new ExceptionLog(message, stackTrace, occurredAt, path, method);
        } 
    }
}
