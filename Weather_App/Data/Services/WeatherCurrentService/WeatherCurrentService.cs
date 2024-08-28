using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Weather_App.Models.Dto.WeatherCurrent;
using Weather_App.Models.Entities;

namespace Weather_App.Data.Services.WeatherCurrentService;

public class WeatherCurrentService : IWeatherCurrentService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public WeatherCurrentService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WeatherCurrentDto>> GetWeatherCurrents()
    {
        return await _context.WeatherCurrent
            .AsNoTracking()
            .OrderByDescending(w => w.Id)
            .ProjectTo<WeatherCurrentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<WeatherCurrentDto>> GetWeatherCurrents(string accountId)
    {
        return await _context.WeatherCurrent
            .AsNoTracking()
            .Where(a => a.AccountId == accountId)
            .OrderByDescending(w => w.Id)
            .ProjectTo<WeatherCurrentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
