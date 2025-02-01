using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Consts;
using WeatherApp.Data.Services.ExternalApisService;
using WeatherApp.Shared.Models.Entities;

namespace WeatherApp.Controllers;

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

    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> SyncWeatherCurrent(string param)
    {
        await _weatherCurrentExternalApiSyncService.BeginRequest(param);

        return RedirectToInfoIndex();
    }

    [Authorize]
    public async Task<IActionResult> SyncWeatherForecast(string param)
    {
        await _weatherForecastExternalApiSyncService.BeginRequest(param);

        return RedirectToInfoIndex();
    }

    private ActionResult RedirectToInfoIndex() =>
        RedirectToAction("Index", ControllerContext.ActionDescriptor.ActionName.Replace("Sync", ""));
}
