using Microsoft.AspNetCore.Mvc;

namespace Comp584api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] //everyone public method is an action
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IEnumerable<string> GetAttributes() 
        {
            return Summaries;
        }
    }
}