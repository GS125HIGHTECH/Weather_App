using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Entities
{
    public class Location : EntityBase<long>
    {
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string? TimeZone { get; set; }
        public long? LocaltimeEpoch { get; set; }
        public DateTime? Localtime { get; set; }
    }
}
