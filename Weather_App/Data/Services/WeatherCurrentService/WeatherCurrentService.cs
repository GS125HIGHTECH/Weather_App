using Microsoft.EntityFrameworkCore;
using Weather_App.Models.Entities;

namespace Weather_App.Data.Services.WeatherCurrentService;

public class WeatherCurrentService : IWeatherCurrentService
{
    private readonly ApplicationDbContext _context;

    public WeatherCurrentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WeatherCurrent>> GetWeatherCurrents()
    {
        return await _context.WeatherCurrent
        .Include(w => w.Current).ThenInclude(w => w.Condition)
        .Include(w => w.Location)
        .Include(w => w.Account)
        .OrderByDescending(w => w.Id)
        .ToListAsync();
    }

    public async Task<IEnumerable<WeatherCurrent>> GetWeatherCurrents(string accountId)
    {
        return await _context.WeatherCurrent
        .Include(w => w.Current).ThenInclude(w => w.Condition)
        .Include(w => w.Location)
        .Include(w => w.Account).Where(a => a.AccountId == accountId)
        .OrderByDescending(w => w.Id)
        .ToListAsync();
    }
}
