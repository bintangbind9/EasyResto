using EasyResto.Domain.Entities;
using EasyResto.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyResto.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AuthHelpers _authHelpers;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AuthHelpers authHelpers)
        {
            _logger = logger;
            _authHelpers = authHelpers;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            AppUser user = new AppUser { Name = "Bintang", IsActive = true, Password ="123", Username = "bintang", Id = 1};
            string jwt = _authHelpers.GenerateJWTToken(user);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
