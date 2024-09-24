using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using ProfileCollector.Application.Commands.Users;
using ProfileCollector.Application.Queries.Users;
using ProfileCollector.Infrastructure.Interfaces;

namespace ProfileCollector.Server.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : BaseController
    {
        private readonly string _controllerEndpoint = "/api/users";

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            var location = $"{_controllerEndpoint}/{response.UserId}";

            return Created(location, response);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetAsync([FromRoute] GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
