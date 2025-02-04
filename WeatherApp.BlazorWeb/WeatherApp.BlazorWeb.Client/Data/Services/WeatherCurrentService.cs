using System.Net.Http.Json;
using WeatherApp.Shared.Data.Services.WeatherCurrentService;
using WeatherApp.Shared.Models.Dto.WeatherCurrent;

namespace WeatherApp.BlazorWeb.Client.Data.Services;

public class WeatherCurrentService : IWeatherCurrentService
{
    private readonly HttpClient _httpClient;

    public WeatherCurrentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<WeatherCurrentBlazorDto>> GetWeatherCurrents()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherCurrentBlazorDto>>("api/WeatherCurrent");
    }

    public async Task<IEnumerable<WeatherCurrentBlazorDto>> GetWeatherCurrents(string accountId)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherCurrentBlazorDto>>($"api/WeatherCurrent/{accountId}");
    }
}
