using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Entities
{
    public class ForecastHour : EntityBase<long>
    {
        public long ForecastDayId { get; set; }
        public virtual ForecastDay? ForecastDay { get; set; }
        public long? TimeEpoch { get; set; }
        public DateTime? Time { get; set; }
        public float? TemperatureCelsius { get; set; }
        public float? TemperatureFahrenheit { get; set; }
        public bool IsDay { get; set; }
        public float? WindMPH { get; set; }
        public float? WindKPH { get; set; }
        public float? WindDegree { get; set; }
        public string? WindDirection { get; set; }
        public float? PressureMilibars { get; set; }
        public float? PressureHgInches { get; set; }
        public float? PrecipMillimetres { get; set; }
        public float? PrecipInches { get; set; }
        public float? SnowCentimeters { get; set; }
        public float? Humidity { get; set; }
        public float? Cloud { get; set; }
        public float? FeelsLikeTemperatureCelsius { get; set; }
        public float? FeelsLikeTemperatureFahrenheit { get; set; }
        public float? WindChillCelsius { get; set; }
        public float? WindChillFahrenheit { get; set; }
        public float? HeatIndexCelsius { get; set; }
        public float? HeatIndexFahrenheit { get; set; }
        public float? DewpointCelsius { get; set; }
        public float? DewpointFahrenheit { get; set; }
        public bool WillItRain { get; set; }
        public int? ChanceOfRain { get; set; }
        public bool WillItSnow { get; set; }
        public int? ChanceOfSnow { get; set; }
        public float? VisibilityKilometers { get; set; }
        public float? VisibilityMiles { get; set; }
        public float? GustMPH { get; set; }
        public float? GustKPH { get; set; }
        public float? UVIndex { get; set; }
        public long ConditionId { get; set; }
        public virtual Condition? Condition { get; set; }
    }
}