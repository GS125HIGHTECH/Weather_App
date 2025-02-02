using WeatherApp.Shared.Models.Dto.WeatherCurrent;
using WeatherApp.Shared.Models.Entities.Shared.EntityBase;

namespace WeatherApp.Shared.Models.Dto.WeatherForecast;

public class ForecastHourBlazorDto : EntityBase<long>
{
    public long ForecastDayId { get; set; }
    public virtual ForecastDayBlazorDto? ForecastDay { get; set; }
    public DateTime? Time { get; set; }
    public float? TemperatureCelsius { get; set; }
    public long ConditionId { get; set; }
    public virtual ConditionDto? Condition { get; set; }
}
