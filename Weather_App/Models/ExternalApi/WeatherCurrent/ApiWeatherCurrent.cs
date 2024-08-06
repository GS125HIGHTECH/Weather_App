using Newtonsoft.Json;

namespace Weather_App.Models.ExternalApi.WeatherCurrent
{
    public class ApiWeatherForecast
    {
        [JsonProperty("location")]
        public ApiWeatherLocation? Location { get; set; }
        [JsonProperty("current")]
        public ApiWeatherCurrent? Current { get; set; }
    }
}
