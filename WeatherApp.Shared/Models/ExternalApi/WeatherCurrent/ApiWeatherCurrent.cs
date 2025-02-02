using Newtonsoft.Json;

namespace WeatherApp.Shared.Models.ExternalApi.WeatherCurrent
{
    public class ApiWeatherRealtime
    {
        [JsonProperty("location")]
        public ApiWeatherLocation? Location { get; set; }
        [JsonProperty("current")]
        public ApiWeatherCurrent? Current { get; set; }
    }
}
