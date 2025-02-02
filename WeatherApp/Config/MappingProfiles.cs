using AutoMapper;
using WeatherApp.Shared.Models.Dto.WeatherCurrent;
using WeatherApp.Shared.Models.Entities;
using WeatherApp.Shared.Models.Dto.WeatherForecast;

namespace WeatherApp.Config;

public class MappingProfiles : Profile
{
    public MappingProfiles() 
    {
        CreateMap<WeatherCurrent, WeatherCurrentDto>();
        CreateMap<Location, LocationDto>();
        CreateMap<Current, CurrentDto>();
        CreateMap<Condition, ConditionDto>();
        CreateMap<WeatherForecast, WeatherForecastDto>();
        CreateMap<ForecastDay, ForecastDayDto>();
        CreateMap<ForecastHour, ForecastHourDto>();
    }
}
