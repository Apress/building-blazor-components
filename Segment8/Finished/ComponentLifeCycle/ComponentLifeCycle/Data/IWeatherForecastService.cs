using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentLifeCycle.Data
{
  interface IWeatherForecastService
  {
    ValueTask<IEnumerable<WeatherForecast>> GetForecastAsync(DateTime startDate);
  }
}
