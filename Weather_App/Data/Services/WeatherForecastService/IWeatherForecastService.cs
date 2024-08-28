using Weather_App.Models.Dto.WeatherForecast;

namespace Weather_App.Data.Services.WeatherForecastService;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecastDto>> GetWeatherForecasts();
    Task<IEnumerable<WeatherForecastDto>> GetWeatherForecasts(string accountId);
}
