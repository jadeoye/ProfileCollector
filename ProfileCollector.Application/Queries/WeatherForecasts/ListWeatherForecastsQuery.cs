using MediatR;
using ProfileCollector.Application.QueryHandlers.WeatherForecasts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.Queries.WeatherForecasts
{
    public class ListWeatherForecastsQuery : IRequest<ListWeatherForecastResponse>
    {
    }
}
