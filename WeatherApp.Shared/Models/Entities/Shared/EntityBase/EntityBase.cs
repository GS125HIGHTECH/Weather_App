using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Shared.Models.Entities.Shared.EntityBase;

public abstract class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
{
    [Key]
    public TPrimaryKey Id { get; set; }
}