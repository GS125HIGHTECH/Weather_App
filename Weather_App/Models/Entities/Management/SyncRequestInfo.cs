using System.ComponentModel.DataAnnotations;
using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Models.Entities.Management;

public class SyncRequestInfo : EntityBase<long>
{
    public long ExecutionTime { get; set; }

    [StringLength(10)]
    [Required]
    public string Status { get; set; }

    [StringLength(50)]
    public string? BaseEntity { get; set; }
    [StringLength(300)]
    public string? AdditionalEntities { get; set; }

    [StringLength(50)]
    public string? ApiName { get; set; }

    [StringLength(100)]
    public string? BaseAddress { get; set; }

    [StringLength(100)]
    public string? EndPoint { get; set; }

    [StringLength(300)]
    public string? Parameters { get; set; }

    public DateTime When { get; set; }

    public int GlobalCount { get; set; }

    [Range(1, 10)]
    public int Reconnections { get; set; }

    [StringLength(2500)]
    public string? Description { get; set; }

    [StringLength(2500)]
    public string? AdditionalInformations { get; set; }

    public string? ProcessingDetails { get; set; }
}
