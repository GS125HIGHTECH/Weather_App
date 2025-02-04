using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.BlazorWeb.Models.Entities;
using WeatherApp.Shared.Data.Services.ExternalApisService;

namespace WeatherApp.BlazorWeb.Controllers;

[Route("ApiDataSync")]
public class ApiDataSyncController : Controller
{
    private readonly IExternalApiSyncService<long, WeatherCurrentBlazor, WeatherCurrentBlazor> _weatherCurrentExternalApiSyncService;
    private readonly IExternalApiSyncService<long, WeatherForecastBlazor, WeatherForecastBlazor> _weatherForecastExternalApiSyncService;

    public ApiDataSyncController(
        IExternalApiSyncService<long, WeatherCurrentBlazor, WeatherCurrentBlazor> weatherCurrentExternalApiSyncService,
        IExternalApiSyncService<long, WeatherForecastBlazor, WeatherForecastBlazor> weatherForecastExternalApiSyncService)
    {
        _weatherCurrentExternalApiSyncService = weatherCurrentExternalApiSyncService;
        _weatherForecastExternalApiSyncService = weatherForecastExternalApiSyncService;
    }

    [Authorize]
    [HttpGet("SyncWeatherCurrent")]
    public async Task<IActionResult> SyncWeatherCurrent(string param)
    {
        await _weatherCurrentExternalApiSyncService.BeginRequest(param);

        return RedirectToInfoIndex();
    }

    [Authorize]
    [HttpGet("SyncWeatherForecast")]
    public async Task<IActionResult> SyncWeatherForecast(string param)
    {
        await _weatherForecastExternalApiSyncService.BeginRequest(param);

        return RedirectToInfoIndex();
    }

    private RedirectResult RedirectToInfoIndex()
    {
        return Redirect("/");
    }
}
