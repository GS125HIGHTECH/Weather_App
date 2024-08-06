using Newtonsoft.Json;

namespace Weather_App.Models.ExternalApi
{
    public class ApiWeatherCurrent
    {
        [JsonProperty("last_updated_epoch")]
        public long? LastUpdatedEpoch { get; set; }
        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; set; }
        [JsonProperty("temp_c")]
        public float? TemperatureCelsius { get; set; }
        [JsonProperty("temp_f")]
        public float? TemperatureFahrenheit { get; set; }
        [JsonProperty("is_day")]
        public bool IsDay { get; set; }
        [JsonProperty("condition")]
        public ApiWeatherCondition? Condition { get; set; }
        [JsonProperty("wind_mph")]
        public float? WindMPH { get; set; }
        [JsonProperty("wind_kph")]
        public float? WindKPH { get; set; }
        [JsonProperty("wind_degree")]
        public float? WindDegree { get; set; }
        [JsonProperty("wind_dir")]
        public string? WindDirection { get; set; }
        [JsonProperty("pressure_mb")]
        public float? PressureMilibars { get; set; }
        [JsonProperty("pressure_in")]
        public float? PressureHgInches { get; set; }
        [JsonProperty("precip_mm")]
        public float? PrecipMillimetres { get; set; }
        [JsonProperty("precip_in")]
        public float? PrecipInches { get; set; }
        [JsonProperty("humidity")]
        public float? Humidity { get; set; }
        [JsonProperty("cloud")]
        public float? Cloud { get; set; }
        [JsonProperty("feelslike_c")]
        public float? FeelsLikeTemperatureCelsius { get; set; }
        [JsonProperty("feelslike_f")]
        public float? FeelsLikeTemperatureFahrenheit { get; set; }
        [JsonProperty("windchill_c")]
        public float? WindChillCelsius { get; set; }
        [JsonProperty("windchill_f")]
        public float? WindChillFahrenheit { get; set; }
        [JsonProperty("heatindex_c")]
        public float? HeatIndexCelsius { get; set; }
        [JsonProperty("heatindex_f")]
        public float? HeatIndexFahrenheit { get; set; }
        [JsonProperty("dewpoint_c")]
        public float? DewpointCelsius { get; set; }
        [JsonProperty("dewpoint_f")]
        public float? DewpointFahrenheit { get; set; }
        [JsonProperty("vis_km")]
        public float? VisibilityKilometers { get; set; }
        [JsonProperty("vis_miles")]
        public float? VisibilityMiles { get; set; }
        [JsonProperty("uv")]
        public float? UVIndex { get; set; }
        [JsonProperty("gust_mph")]
        public float? GustMPH { get; set; }
        [JsonProperty("gust_kph")]
        public float? GustKPH { get; set; }
    }
}