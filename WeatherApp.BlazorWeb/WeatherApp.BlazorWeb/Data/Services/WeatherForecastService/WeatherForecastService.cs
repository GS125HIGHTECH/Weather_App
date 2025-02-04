using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Shared.Data.Services.WeatherForecastService;
using WeatherApp.Shared.Models.Dto.WeatherForecast;

namespace WeatherApp.BlazorWeb.Data.Services.WeatherForecastService;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public WeatherForecastService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WeatherForecastBlazorDto>> GetWeatherForecasts()
    {
        return await _context.WeatherForecast!
            .AsNoTracking()
            .OrderByDescending(w => w.Id)
            .ProjectTo<WeatherForecastBlazorDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<WeatherForecastBlazorDto>> GetWeatherForecasts(string accountId)
    {
        return await _context.WeatherForecast!
            .AsNoTracking()
            .Where(a => a.AccountId == accountId)
            .OrderByDescending(w => w.Id)
            .ProjectTo<WeatherForecastBlazorDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
