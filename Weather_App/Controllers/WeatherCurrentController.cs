using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Weather_App.Consts;
using Weather_App.Data.Services.WeatherCurrentService;

namespace Weather_App.Controllers;

[Authorize(Roles = Roles.Administrator)]
public class WeatherCurrentController : Controller
{
    private readonly IWeatherCurrentService _service;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WeatherCurrentController(IWeatherCurrentService service, 
        UserManager<IdentityUser> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _service = service;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

        var weatherForecasts = await _service.GetWeatherCurrents(user.Id);

        return View(weatherForecasts);
    }

    public async Task<IActionResult> AdminPanel()
    {
        var weatherForecasts = await _service.GetWeatherCurrents();

        return View(weatherForecasts);
    }
}
