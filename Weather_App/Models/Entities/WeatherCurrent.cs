using Betort.Models.Entities.Shared.EntityBase;
using Microsoft.AspNetCore.Identity;

namespace Weather_App.Models.Entities
{
    public class WeatherCurrent : EntityBase<long>
    {
        public string? AccountId { get; set; }
        public virtual IdentityUser? Account { get; set; }
        public long LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public long CurrentId { get; set; }
        public virtual Current? Current { get; set; }
    }
}
