using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentLibraries.Data
{
  public class WeatherForecastService : IWeatherForecastService
  {
    private static readonly string[] Summaries = new[]
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async ValueTask<IEnumerable<WeatherForecast>> GetForecastAsync(DateTime startDate)
    {
      var rng = new Random();

      // Fake some delay
      await Task.Delay(rng.Next(300, 800));

      return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = startDate.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      }).ToArray());
    }
  }
}
