using WeatherApp.Shared.Models.Entities.Shared.EntityBase;

namespace WeatherApp.Shared.Models.Dto.WeatherCurrent;

public class LocationDto : EntityBase<long>
{
    public string? Name { get; set; }
    public string? Country { get; set; }
    public DateTime? Localtime { get; set; }
}
