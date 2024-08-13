using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weather_App.Consts;
using Weather_App.Data.Services.WeatherForecastService;

namespace Weather_App.Controllers;

[Authorize(Roles = Roles.Administrator)]
public class WeatherForecastController : Controller
{
    private readonly IWeatherForecastService _service;

    public WeatherForecastController(IWeatherForecastService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var weatherForecasts = await _service.GetWeatherForecasts();

        return View(weatherForecasts);
    }
}
