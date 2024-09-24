using Microsoft.AspNetCore.Mvc.Filters;
using ProfileCollector.Domain.Entities;
using ProfileCollector.Infrastructure.Interfaces;

namespace ProfileCollector.Server.Filters
{
    public class ExceptionLoggerFilter : IAsyncExceptionFilter
    {
        private readonly IExceptionLogger _logger;
        public ExceptionLoggerFilter(IExceptionLogger logger)
        {
            _logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var ex = context.Exception;

            var log = ExceptionLog.Create(ex.Message, ex.StackTrace, DateTime.UtcNow, context.HttpContext.Request.Path, context.HttpContext.Request.Method);

            await _logger.LogAsync(log);

            context.ExceptionHandled = true;
        }
    }
}
