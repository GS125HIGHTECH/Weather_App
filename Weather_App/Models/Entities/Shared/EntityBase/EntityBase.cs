using System.ComponentModel.DataAnnotations;

namespace Weather_App.Models.Entities.Shared.EntityBase;

public abstract class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
{
    [Key]
    public TPrimaryKey Id { get; set; }
}