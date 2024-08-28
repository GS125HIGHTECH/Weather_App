using AutoMapper;
using Weather_App.Models.Dto.WeatherCurrent;
using Weather_App.Models.Dto.WeatherForecast;
using Weather_App.Models.Entities;

namespace Weather_App.Config;

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
