using WeatherApp.Shared.Models.Dto.WeatherForecast;

namespace WeatherApp.Blazor.Data.Services.WeatherForecastService;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecastBlazorDto>> GetWeatherForecasts();
    Task<IEnumerable<WeatherForecastBlazorDto>> GetWeatherForecasts(string accountId);
}
