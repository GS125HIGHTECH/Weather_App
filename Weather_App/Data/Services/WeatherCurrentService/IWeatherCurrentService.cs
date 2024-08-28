using Weather_App.Models.Dto.WeatherCurrent;

namespace Weather_App.Data.Services.WeatherCurrentService;

public interface IWeatherCurrentService
{
    Task<IEnumerable<WeatherCurrentDto>> GetWeatherCurrents();
    Task<IEnumerable<WeatherCurrentDto>> GetWeatherCurrents(string accountId);
}
