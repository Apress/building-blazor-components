using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentLibraries.Data
{
  interface IWeatherForecastService
  {
    ValueTask<IEnumerable<WeatherForecast>> GetForecastAsync(DateTime startDate);
  }
}
