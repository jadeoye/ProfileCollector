using ProfileCollector.Application.Dtos.WeatherForecasts;
using ProfileCollector.Application.Interfaces.Repositories;
using ProfileCollector.Domain.Entities;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly IAsyncDocumentSession _session;

        public WeatherForecastRepository(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<List<WeatherForecastDto>> ListAsync()
        {
            var forecasts = await _session.Query<WeatherForecast>().ToListAsync();

            var response = forecasts.Select(x => new WeatherForecastDto
            {
                Date = x.Date,
                Summary = x.Summary,
                TemperatureC = x.TemperatureC,
                TemperatureF = x.TemperatureF
            }).ToList();

            return response;
        }
    }
}
