using AutoMapper;
using WeatherApp.Blazor.Models.Entities;
using WeatherApp.Shared.Models.Dto.WeatherCurrent;
using WeatherApp.Shared.Models.Dto.WeatherForecast;
using WeatherApp.Shared.Models.Entities;

namespace WeatherApp.Blazor.Config;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<WeatherCurrentBlazor, WeatherCurrentBlazorDto>();
        CreateMap<Location, LocationDto>();
        CreateMap<Current, CurrentDto>();
        CreateMap<Condition, ConditionDto>();
        CreateMap<WeatherForecastBlazor, WeatherForecastBlazorDto>();
        CreateMap<ForecastDayBlazor, ForecastDayBlazorDto>();
        CreateMap<ForecastHourBlazor, ForecastHourBlazorDto>();
    }
}
