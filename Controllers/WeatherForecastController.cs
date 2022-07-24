using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        
        private static Random rng = new Random();

        private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            

            if(ListWeatherForecast == null || !ListWeatherForecast.Any()){

                ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToList();
            }
        }

        [HttpGet] 
        public IEnumerable<WeatherForecast> GetW()
        {            
            _logger.LogInformation("retornado la lista");
            return ListWeatherForecast;
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast){
            ListWeatherForecast.Add(weatherForecast);

            return Ok();
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index){
            ListWeatherForecast.RemoveAt(index);
            return Ok();
        }
    }
}
