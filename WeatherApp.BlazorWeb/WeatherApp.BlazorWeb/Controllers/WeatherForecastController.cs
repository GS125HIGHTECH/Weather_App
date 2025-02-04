using Microsoft.AspNetCore.Mvc;
using WeatherApp.Shared.Data.Services.WeatherForecastService;
using WeatherApp.Shared.Models.Dto.WeatherForecast;

namespace WeatherApp.BlazorWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecastBlazorDto>> GetWeatherForecasts()
    {
        return await _weatherForecastService.GetWeatherForecasts();
    }

    [HttpGet("{accountId}")]
    public async Task<IEnumerable<WeatherForecastBlazorDto>> GetWeatherForecastsByAccount(string accountId)
    {
        return await _weatherForecastService.GetWeatherForecasts(accountId);
    }
}
