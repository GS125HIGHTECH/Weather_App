using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weather_App.Consts;
using Weather_App.Data.Services.WeatherCurrentService;

namespace Weather_App.Controllers;

[Authorize(Roles = Roles.Administrator)]
public class WeatherCurrentController : Controller
{
    private readonly IWeatherCurrentService _service;

    public WeatherCurrentController(IWeatherCurrentService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var weatherForecasts = await _service.GetWeatherCurrents();

        return View(weatherForecasts);
    }
}
