using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProfileCollector.Application.Common.Exceptions;
using ProfileCollector.Domain.Exceptions;
using ProfileCollector.Server.Utilities;

namespace ProfileCollector.Server.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>()
            {
                { typeof(BusinessRuleException), HandleBusinessRuleException },
                { typeof(NotFoundException), HandleNotFoundException }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();

            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private static void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = $"An error occurred while processing your request. {context.Exception.Message}",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            context.Result = new ObjectResult(details)
            {
                Value = Envelope.Error(details.Title),
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private static void HandleBusinessRuleException(ExceptionContext context)
        {
            var exception = (BusinessRuleException)context.Exception;

            var errors = new Dictionary<string, string[]> { { exception.ParamName, new[] { exception.Message } } };

            var details = new ValidationProblemDetails(errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details)
            {
                Value = Envelope.Error(exception.Message),
            };

            context.ExceptionHandled = true;
        }

        private static void HandleNotFoundException(ExceptionContext context)
        {
            var exception = (NotFoundException)context.Exception;

            var errors = new Dictionary<string, string[]> { { exception.ParamName, new[] { exception.Message } } };

            var details = new ValidationProblemDetails(errors)
            {
                Status = StatusCodes.Status404NotFound,
                Title = "NotFound",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new ObjectResult(details)
            {
                Value = Envelope.NotFound(exception.Message),
                StatusCode = StatusCodes.Status404NotFound
            };

            context.ExceptionHandled = true;
        }

    }
}
