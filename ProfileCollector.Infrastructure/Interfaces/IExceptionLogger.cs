using ProfileCollector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Infrastructure.Interfaces
{
    public interface IExceptionLogger
    {
        Task LogAsync(ExceptionLog log);
    }
}
