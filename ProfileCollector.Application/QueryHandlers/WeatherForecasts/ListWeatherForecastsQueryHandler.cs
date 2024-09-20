using MediatR;
using ProfileCollector.Application.Interfaces.Repositories;
using ProfileCollector.Application.Queries.WeatherForecasts;
using ProfileCollector.Application.QueryHandlers.WeatherForecasts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.QueryHandlers.WeatherForecasts
{
    internal class ListWeatherForecastsQueryHandler : IRequestHandler<ListWeatherForecastsQuery, ListWeatherForecastResponse>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        public ListWeatherForecastsQueryHandler(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;        
        }

        public async Task<ListWeatherForecastResponse> Handle(ListWeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            var data = await _weatherForecastRepository.ListAsync();

            var response = new ListWeatherForecastResponse
            {
                WeatherForecasts = data.ToList()
            };

            return response;
        }
    }
}
