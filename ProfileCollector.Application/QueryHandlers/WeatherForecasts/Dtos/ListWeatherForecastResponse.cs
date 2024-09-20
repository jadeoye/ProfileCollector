using ProfileCollector.Application.Dtos.WeatherForecasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.QueryHandlers.WeatherForecasts.Dtos
{
    public class ListWeatherForecastResponse
    {
        public List<WeatherForecastDto> WeatherForecasts { get; set; }
    }
}
