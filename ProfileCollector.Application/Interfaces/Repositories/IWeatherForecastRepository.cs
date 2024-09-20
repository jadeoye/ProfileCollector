using ProfileCollector.Application.Dtos.WeatherForecasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.Interfaces.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task<List<WeatherForecastDto>> ListAsync();
    }
}
