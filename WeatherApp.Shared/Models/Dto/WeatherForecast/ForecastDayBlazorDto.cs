using WeatherApp.Shared.Models.Entities.Shared.EntityBase;

namespace WeatherApp.Shared.Models.Dto.WeatherForecast;

public class ForecastDayBlazorDto : EntityBase<long>
{
    public long WeatherForecastId { get; set; }
    public virtual WeatherForecastBlazorDto? WeatherForecast { get; set; }
    public DateTime? Date { get; set; }
    public virtual ICollection<ForecastHourBlazorDto>? ForecastHours { get; set; }
}
