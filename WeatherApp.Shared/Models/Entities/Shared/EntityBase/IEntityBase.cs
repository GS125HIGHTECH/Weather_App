using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Shared.Models.Entities.Shared.EntityBase;

public interface IEntityBase<TPrimaryKey>
{
    [Key]
    public TPrimaryKey Id { get; set; }
}