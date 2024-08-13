using Microsoft.EntityFrameworkCore;
using Weather_App.Models.Entities;

namespace Weather_App.Data.Services.WeatherForecastService;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ApplicationDbContext _context;

    public WeatherForecastService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
    {
        return await _context.WeatherForecast
        .Include(w => w.Location)
        .Include(w => w.Account)
        .Include(w => w.ForecastDays).ThenInclude(w => w.ForecastHours).ThenInclude(w => w.Condition)
        .Include(w => w.Current).ThenInclude(w => w.Condition)
        .ToListAsync();
    }
}
