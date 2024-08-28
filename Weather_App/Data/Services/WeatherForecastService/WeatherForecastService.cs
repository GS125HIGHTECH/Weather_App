using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Weather_App.Models.Dto.WeatherCurrent;
using Weather_App.Models.Dto.WeatherForecast;

namespace Weather_App.Data.Services.WeatherForecastService;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public WeatherForecastService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WeatherForecastDto>> GetWeatherForecasts()
    {
        return await _context.WeatherForecast
            .AsNoTracking()
            .OrderByDescending(w => w.Id)
            .ProjectTo<WeatherForecastDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<WeatherForecastDto>> GetWeatherForecasts(string accountId)
    {
        return await _context.WeatherForecast
            .AsNoTracking()
            .Where(a => a.AccountId == accountId)
            .OrderByDescending(w => w.Id)
            .ProjectTo<WeatherForecastDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
