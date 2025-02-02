using WeatherApp.Shared.Models.Entities.Shared.EntityBase;

namespace WeatherApp.Shared.Models.Dto.WeatherCurrent;

public class WeatherCurrentBlazorDto : EntityBase<long>
{
    public string? AccountId { get; set; }
    public long LocationId { get; set; }
    public virtual LocationDto? Location { get; set; }
    public long CurrentId { get; set; }
    public virtual CurrentDto? Current { get; set; }
}
