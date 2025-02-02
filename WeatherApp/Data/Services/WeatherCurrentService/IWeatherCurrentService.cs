using WeatherApp.Shared.Models.Dto.WeatherCurrent;

namespace WeatherApp.Data.Services.WeatherCurrentService;

public interface IWeatherCurrentService
{
    Task<IEnumerable<WeatherCurrentDto>> GetWeatherCurrents();
    Task<IEnumerable<WeatherCurrentDto>> GetWeatherCurrents(string accountId);
}
