using WeatherApp.Shared.Models.Dto.WeatherCurrent;

namespace WeatherApp.Shared.Data.Services.WeatherCurrentService;

public interface IWeatherCurrentService
{
    Task<IEnumerable<WeatherCurrentBlazorDto>> GetWeatherCurrents();
    Task<IEnumerable<WeatherCurrentBlazorDto>> GetWeatherCurrents(string accountId);
}
