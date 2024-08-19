using System.ComponentModel.DataAnnotations;

namespace Weather_App.Models.Entities.Shared.EntityBase;

public interface IEntityBase<TPrimaryKey>
{
    [Key]
    public TPrimaryKey Id { get; set; }
}