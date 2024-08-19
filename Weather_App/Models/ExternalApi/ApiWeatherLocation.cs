using Newtonsoft.Json;

namespace Weather_App.Models.ExternalApi
{
    public class ApiWeatherLocation
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("region")]
        public string? Region { get; set; }
        [JsonProperty("country")]
        public string? Country { get; set; }
        [JsonProperty("lat")]
        public float? Latitude { get; set; }
        [JsonProperty("lon")]
        public float? Longitude { get; set; }
        [JsonProperty("tz_id")]
        public string? TimeZone { get; set; }
        [JsonProperty("localtime_epoch")]
        public long? LocaltimeEpoch { get; set; }
        [JsonProperty("localtime")]
        public DateTime? Localtime { get; set; }
    }
}