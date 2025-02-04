using System.Net.Http.Json;
using WeatherApp.Shared.Data.Services.WeatherForecastService;
using WeatherApp.Shared.Models.Dto.WeatherForecast;

namespace WeatherApp.BlazorWeb.Client.Data.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly HttpClient _httpClient;

    public WeatherForecastService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<WeatherForecastBlazorDto>> GetWeatherForecasts()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecastBlazorDto>>("api/WeatherForecast");
    }

    public async Task<IEnumerable<WeatherForecastBlazorDto>> GetWeatherForecasts(string accountId)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecastBlazorDto>>($"api/WeatherForecast/{accountId}");
    }
}
