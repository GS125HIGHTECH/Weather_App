using Newtonsoft.Json;

namespace Weather_App.Models.ExternalApi.WeatherForecast
{
    public class ApiWeatherForecastDay
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
        [JsonProperty("date_epoch")]
        public long? DateEpoch { get; set; }
        [JsonProperty("day")]
        public ApiWeatherForecastDayDay? Day { get; set; }
        [JsonProperty("astro")]
        public ApiWeatherForecastDayAstro? Astro { get; set; }
        [JsonProperty("hour")]
        public List<ApiWeatherForecastDayHour>? Hours { get; set; }
    }
}
