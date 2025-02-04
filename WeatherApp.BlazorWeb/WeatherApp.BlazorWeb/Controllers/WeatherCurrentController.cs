using Microsoft.AspNetCore.Mvc;
using WeatherApp.Shared.Data.Services.WeatherCurrentService;
using WeatherApp.Shared.Models.Dto.WeatherCurrent;

namespace WeatherApp.BlazorWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherCurrentController : ControllerBase
{
    private readonly IWeatherCurrentService _weatherCurrentService;

    public WeatherCurrentController(IWeatherCurrentService weatherCurrentService)
    {
        _weatherCurrentService = weatherCurrentService;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherCurrentBlazorDto>> GetWeatherCurrents()
    {
        return await _weatherCurrentService.GetWeatherCurrents();
    }

    [HttpGet("{accountId}")]
    public async Task<IEnumerable<WeatherCurrentBlazorDto>> GetWeatherCurrentsByAccount(string accountId)
    {
        return await _weatherCurrentService.GetWeatherCurrents(accountId);
    }
}
