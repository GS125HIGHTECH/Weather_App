using Newtonsoft.Json;

namespace WeatherApp.Shared.Models.ExternalApi.WeatherForecast
{
    public class ApiWeatherForecastForecast
    {
        [JsonProperty("forecastday")]
        public List<ApiWeatherForecastDay>? ForecastDays { get; set; }
    }
}