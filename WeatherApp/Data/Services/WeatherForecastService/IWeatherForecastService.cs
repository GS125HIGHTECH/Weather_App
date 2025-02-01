using WeatherApp.Shared.Models.Dto.WeatherForecast;

namespace WeatherApp.Data.Services.WeatherForecastService;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecastDto>> GetWeatherForecasts();
    Task<IEnumerable<WeatherForecastDto>> GetWeatherForecasts(string accountId);
}
