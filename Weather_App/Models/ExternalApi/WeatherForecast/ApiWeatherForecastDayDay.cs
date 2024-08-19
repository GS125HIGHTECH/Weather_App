using Newtonsoft.Json;

namespace Weather_App.Models.ExternalApi.WeatherForecast
{
    public class ApiWeatherForecastDayDay
    {
        [JsonProperty("maxtemp_c")]
        public float? MaxTemperatureCelsius { get; set; }
        [JsonProperty("maxtemp_f")]
        public float? MaxTemperatureFahrenheit { get; set; }
        [JsonProperty("mintemp_c")]
        public float? MinTemperatureCelsius { get; set; }
        [JsonProperty("mintemp_f")]
        public float? MinTemperatureFahrenheit { get; set; }
        [JsonProperty("avgtemp_c")]
        public float? AvgTemperatureCelsius { get; set; }
        [JsonProperty("avgtemp_f")]
        public float? AvgTemperatureFahrenheit { get; set; }
        [JsonProperty("maxwind_mph")]
        public float? MaxWindMPH { get; set; }
        [JsonProperty("maxwind_kph")]
        public float? MaxWindKPH { get; set; }
        [JsonProperty("totalprecip_mm")]
        public float? TotalPrecipMillimetres { get; set; }
        [JsonProperty("totalprecip_in")]
        public float? TotalPrecipInches { get; set; }
        [JsonProperty("totalsnow_cm")]
        public float? TotalSnowCentimeters { get; set; }
        [JsonProperty("avgvis_km")]
        public float? AvgVisibilityKilometers { get; set; }
        [JsonProperty("avgvis_miles")]
        public float? AvgVisibilityMiles { get; set; }
        [JsonProperty("avghumidity")]
        public int? AvgHumidity { get; set; }
        [JsonProperty("daily_will_it_rain")]
        public bool WillItRain { get; set; }
        [JsonProperty("daily_chance_of_rain")]
        public int? ChanceOfRain { get; set; }
        [JsonProperty("daily_will_it_snow")]
        public bool WillItSnow { get; set; }
        [JsonProperty("daily_chance_of_snow")]
        public int? ChanceOfSnow { get; set; }
        [JsonProperty("condition")]
        public ApiWeatherCondition? Condition { get; set; }
        [JsonProperty("uv")]
        public float? UVIndex { get; set; }
    }
}