using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Entities
{
    public class ForecastDay : EntityBase<long>
    {
        public long WeatherForecastId { get; set; }
        public virtual WeatherForecast? WeatherForecast { get; set; }
        public DateTime? Date { get; set; }
        public long? DateEpoch { get; set; }
        public float? MaxTemperatureCelsius { get; set; }
        public float? MaxTemperatureFahrenheit { get; set; }
        public float? MinTemperatureCelsius { get; set; }
        public float? MinTemperatureFahrenheit { get; set; }
        public float? AvgTemperatureCelsius { get; set; }
        public float? AvgTemperatureFahrenheit { get; set; }
        public float? MaxWindMPH { get; set; }
        public float? MaxWindKPH { get; set; }
        public float? TotalPrecipMillimetres { get; set; }
        public float? TotalPrecipInches { get; set; }
        public float? TotalSnowCentimeters { get; set; }
        public float? AvgVisibilityKilometers { get; set; }
        public float? AvgVisibilityMiles { get; set; }
        public int? AvgHumidity { get; set; }
        public bool WillItRain { get; set; }
        public int? ChanceOfRain { get; set; }
        public bool WillItSnow { get; set; }
        public int? ChanceOfSnow { get; set; }
        public float? UVIndex { get; set; }
        public long ConditionId { get; set; }
        public virtual Condition? Condition { get; set; }
        public long AstroId { get; set; }
        public virtual Astro? Astro { get; set; }
        public virtual ICollection<ForecastHour>? ForecastHours { get; set; }
    }
}