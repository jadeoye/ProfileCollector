using ProfileCollector.Domain.Entities;
using ProfileCollector.Infrastructure.Interfaces;

namespace ProfileCollector.Server.Middlewares
{
    public class ExceptionLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var logger = context.RequestServices.GetRequiredService<IExceptionLogger>();

                var log = ExceptionLog.Create(ex.Message, ex.StackTrace, DateTime.UtcNow, context.Request.Path, context.Request.Method);

                await logger.LogAsync(log);
            }
        }
    }
}
