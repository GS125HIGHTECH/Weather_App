using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Dto.WeatherForecast;

public class ForecastDayDto : EntityBase<long>
{
    public long WeatherForecastId { get; set; }
    public virtual WeatherForecastDto? WeatherForecast { get; set; }
    public DateTime? Date { get; set; }
    public virtual ICollection<ForecastHourDto>? ForecastHours { get; set; }
}
