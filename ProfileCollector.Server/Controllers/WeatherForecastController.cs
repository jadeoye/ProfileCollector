using Microsoft.AspNetCore.Mvc;
using ProfileCollector.Application.Queries.WeatherForecasts;
using ProfileCollector.Application.QueryHandlers.WeatherForecasts.Dtos;

namespace ProfileCollector.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<ListWeatherForecastResponse>> Get(CancellationToken cancellationToken)
        {
            var request = new ListWeatherForecastsQuery();
            var response = await Mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
