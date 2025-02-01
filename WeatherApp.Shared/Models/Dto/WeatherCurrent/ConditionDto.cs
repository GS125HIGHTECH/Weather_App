using WeatherApp.Shared.Models.Entities.Shared.EntityBase;

namespace WeatherApp.Shared.Models.Dto.WeatherCurrent;

public class ConditionDto : EntityBase<long>
{
    public string? Text { get; set; }
    public string? Icon { get; set; }
}
