using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new List<string>
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Count)]
            })
            .ToArray();
        }
        [HttpPost(Name = "PostWeatherForecast")]
        public List<string> Post(string weather)
        {
            Summaries.Add(weather);
            return Summaries;
        }

        /* public int PostStatusCode(string url)
         {

         }*/
        [ProducesResponseType(statusCode:StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode:StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode:StatusCodes.Status500InternalServerError)]
        [HttpDelete(Name = "DeleteWeatherForecast")]
        public IActionResult Delete(int index)
        {
            if (index < Summaries.Count)
            {
                Summaries.RemoveAt(index);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }
}
