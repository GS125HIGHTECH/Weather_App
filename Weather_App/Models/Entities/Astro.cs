using Betort.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Entities
{
    public class Astro : EntityBase<long>
    {
        public string? Sunrise { get; set; }
        public string? Sunset { get; set; }
        public string? Moonrise { get; set; }
        public string? Moonset { get; set; }
        public string? MoonPhase { get; set; }
        public float? MoonIllumination { get; set; }
        public bool IsMoonUp { get; set; }
        public bool IsSunUp { get; set; }
    }
}