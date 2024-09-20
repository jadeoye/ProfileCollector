using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Domain.Entities
{
    public class WeatherForecast
    {
        public DateTime Date { get; private set; }

        public int TemperatureC { get; private set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; private set; }
    }
}
