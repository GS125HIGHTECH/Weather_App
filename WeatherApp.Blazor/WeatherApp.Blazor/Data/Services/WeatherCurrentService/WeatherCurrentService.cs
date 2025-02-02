using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Shared.Models.Dto.WeatherCurrent;

namespace WeatherApp.Blazor.Data.Services.WeatherCurrentService;

public class WeatherCurrentService : IWeatherCurrentService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public WeatherCurrentService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WeatherCurrentBlazorDto>> GetWeatherCurrents()
    {
        return await _context.WeatherCurrent
            .AsNoTracking()
            .OrderByDescending(w => w.Id)
            .ProjectTo<WeatherCurrentBlazorDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<WeatherCurrentBlazorDto>> GetWeatherCurrents(string accountId)
    {
        return await _context.WeatherCurrent
            .AsNoTracking()
            .Where(a => a.AccountId == accountId)
            .OrderByDescending(w => w.Id)
            .ProjectTo<WeatherCurrentBlazorDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
