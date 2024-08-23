using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Weather_App.Consts;
using Weather_App.Data.Services.WeatherForecastService;

namespace Weather_App.Controllers;

public class WeatherForecastController : Controller
{
    private readonly IWeatherForecastService _service;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WeatherForecastController(IWeatherForecastService service,
        UserManager<IdentityUser> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

        var weatherForecasts = await _service.GetWeatherForecasts(user.Id);

        return View(weatherForecasts);
    }

    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> AdminPanel()
    {
        var weatherForecasts = await _service.GetWeatherForecasts();

        return View(weatherForecasts);
    }
}
