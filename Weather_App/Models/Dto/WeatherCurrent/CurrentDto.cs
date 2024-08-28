using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Dto.WeatherCurrent;

public class CurrentDto : EntityBase<long>
{
    public float? TemperatureCelsius { get; set; }
    public float? TemperatureFahrenheit { get; set; }
    public float? WindMPH { get; set; }
    public float? WindKPH { get; set; }
    public float? PressureMilibars { get; set; }
    public float? Humidity { get; set; }
    public float? FeelsLikeTemperatureCelsius { get; set; }
    public float? FeelsLikeTemperatureFahrenheit { get; set; }
    public float? VisibilityKilometers { get; set; }
    public float? UVIndex { get; set; }
    public long ConditionId { get; set; }
    public virtual ConditionDto? Condition { get; set; }
}
