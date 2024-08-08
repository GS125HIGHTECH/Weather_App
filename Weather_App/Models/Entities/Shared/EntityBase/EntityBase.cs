using System.ComponentModel.DataAnnotations;

namespace Betort.Models.Entities.Shared.EntityBase;

public abstract class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
{
    [Key]
    public TPrimaryKey Id { get; set; }
}