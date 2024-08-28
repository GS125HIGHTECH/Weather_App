using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Dto.WeatherCurrent;

public class ConditionDto : EntityBase<long>
{
    public string? Text { get; set; }
    public string? Icon { get; set; }
}
