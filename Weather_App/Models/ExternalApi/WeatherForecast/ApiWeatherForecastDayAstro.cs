using Newtonsoft.Json;

namespace Weather_App.Models.ExternalApi.WeatherForecast
{
    public class ApiWeatherForecastDayAstro
    {
        [JsonProperty("sunrise")]
        public string? Sunrise { get; set; }
        [JsonProperty("sunset")]
        public string? Sunset { get; set; }
        [JsonProperty("moonrise")]
        public string? Moonrise { get; set; }
        [JsonProperty("moonset")]
        public string? Moonset { get; set; }
        [JsonProperty("moon_phase")]
        public string? MoonPhase { get; set; }
        [JsonProperty("moon_illumination")]
        public float? MoonIllumination { get; set; }
        [JsonProperty("is_moon_up")]
        public bool IsMoonUp { get; set; }
        [JsonProperty("is_sun_up")]
        public bool IsSunUp { get; set; }
    }
}