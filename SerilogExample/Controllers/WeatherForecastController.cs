using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Import the ILogger namespace
using Serilog; // Import Serilog namespace
using System;
using System.Collections.Generic;
using System.Linq;
using SerilogExample.Models; // Make sure to import the WeatherForecast model

namespace SerilogExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
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
            _logger.LogInformation("Retrieving weather forecast data.");

            try
            {
                var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

                _logger.LogInformation("Weather forecast data retrieved successfully.");

                return forecasts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving weather forecast data.");
                throw;
            }
        }
    }
}
