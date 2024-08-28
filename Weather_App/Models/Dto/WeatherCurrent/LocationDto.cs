using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Dto.WeatherCurrent;

public class LocationDto : EntityBase<long>
{
    public string? Name { get; set; }
    public string? Country { get; set; }
    public DateTime? Localtime { get; set; }
}
