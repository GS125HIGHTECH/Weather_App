using Betort.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Entities
{
    public class Condition : EntityBase<long>
    {
        public string? Text { get; set; }
        public string? Icon { get; set; }
        public int? Code { get; set; }
    }
}
