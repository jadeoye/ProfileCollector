using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfileCollector.Server.Utilities;

namespace ProfileCollector.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private ISender? _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        protected new ActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected ActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected new ActionResult Accepted()
        {
            return base.Accepted(Envelope.Accepted());
        }

        protected ActionResult Accepted<T>(T result)
        {
            return base.Accepted(Envelope.Accepted(result));
        }

        protected new ActionResult Created(string url, object data)
        {
            return base.Created(url, Envelope.Created(data));
        }

        protected ActionResult Created<T>(string url, T result)
        {
            return base.Created(url, Envelope.Created(result));
        }
    }
}
