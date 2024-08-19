using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weather_App.Consts;
using Weather_App.Data.Services.ExternalApisService;
using Weather_App.Models.Entities;

namespace Weather_App.Controllers;

[Authorize(Roles = Roles.Administrator)]
public class ApiDataSyncController : Controller
{
    private readonly IExternalApiSyncService<long, WeatherCurrent, WeatherCurrent> _weatherCurrentExternalApiSyncService;
    private readonly IExternalApiSyncService<long, WeatherForecast, WeatherForecast> _weatherForecastExternalApiSyncService;

    public ApiDataSyncController(
        IExternalApiSyncService<long, WeatherCurrent, WeatherCurrent> weatherCurrentExternalApiSyncService,
        IExternalApiSyncService<long, WeatherForecast, WeatherForecast> weatherForecastExternalApiSyncService)
    {
        _weatherCurrentExternalApiSyncService = weatherCurrentExternalApiSyncService;
        _weatherForecastExternalApiSyncService = weatherForecastExternalApiSyncService;
    }

    public async Task<IActionResult> SyncWeatherCurrent(string param)
    {
        await _weatherCurrentExternalApiSyncService.BeginRequest(param);

        return RedirectToInfoIndex();
    }

    public async Task<IActionResult> SyncWeatherForecast(string param)
    {
        await _weatherForecastExternalApiSyncService.BeginRequest(param);

        return RedirectToInfoIndex();
    }

    private ActionResult RedirectToInfoIndex() =>
        RedirectToAction("Index", "Home");
}
