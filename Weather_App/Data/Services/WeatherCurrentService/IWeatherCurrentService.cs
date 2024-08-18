using Weather_App.Models.Entities;

namespace Weather_App.Data.Services.WeatherCurrentService;

public interface IWeatherCurrentService
{
    Task<IEnumerable<WeatherCurrent>> GetWeatherCurrents();
}
