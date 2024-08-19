using Newtonsoft.Json;

namespace Weather_App.Models.ExternalApi
{
    public class ApiWeatherCondition
    {
        [JsonProperty("text")]
        public string? Text { get; set; }
        [JsonProperty("icon")]
        public string? Icon { get; set; }
        [JsonProperty("code")]
        public int? Code { get; set; }
    }
}
