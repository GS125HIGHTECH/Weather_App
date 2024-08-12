using Newtonsoft.Json;

namespace Weather_App.Models.ExternalApi.WeatherForecast
{
    public class ApiWeatherForecastForecast
    {
        [JsonProperty("forecastday")]
        public List<ApiWeatherForecastDay>? ForecastDays { get; set; }
    }
}