using Weather_App.Models.Entities;

namespace Weather_App.Data.Services.WeatherForecastService;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecasts();
}
