using Weather_App.Models.Dto.WeatherCurrent;
using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Dto.WeatherForecast;

public class ForecastHourDto : EntityBase<long>
{
    public long ForecastDayId { get; set; }
    public virtual ForecastDayDto? ForecastDay { get; set; }
    public DateTime? Time { get; set; }
    public float? TemperatureCelsius { get; set; }
    public long ConditionId { get; set; }
    public virtual ConditionDto? Condition { get; set; }
}
