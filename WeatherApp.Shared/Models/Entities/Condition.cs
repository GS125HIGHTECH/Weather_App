using WeatherApp.Shared.Models.Entities.Shared.EntityBase;

namespace WeatherApp.Shared.Models.Entities
{
    public class Condition : EntityBase<long>
    {
        public string? Text { get; set; }
        public string? Icon { get; set; }
        public int? Code { get; set; }
    }
}
