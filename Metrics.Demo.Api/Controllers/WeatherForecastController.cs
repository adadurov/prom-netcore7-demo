using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Metrics.Demo.Api.Controllers;

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

    [HttpGet(Name = "GetWeatherForecast", Order = 1)]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var rng = new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

        await Task.Delay(rng.Next(10, 500));

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("NotFound", Order = 3)]
    public IActionResult ReturnNotFound()
    {
        return StatusCode((int)HttpStatusCode.NotFound);
    }

    [HttpGet("InternalServerError", Order = 4)]
    public IActionResult ReturnInternalServerError()
    {
        return StatusCode((int)HttpStatusCode.InternalServerError);
    }

}
