using WeatherApp.Blazor.Data;
using WeatherApp.Shared.Models.Entities;
using WeatherApp.Shared.Models.Entities.Shared.EntityBase;

namespace WeatherApp.Blazor.Models.Entities
{
    public class WeatherCurrentBlazor : EntityBase<long>
    {
        public string? AccountId { get; set; }
        public virtual ApplicationUser? Account { get; set; }
        public long LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public long CurrentId { get; set; }
        public virtual Current? Current { get; set; }
    }
}
