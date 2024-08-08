using System.ComponentModel.DataAnnotations;

namespace Betort.Models.Entities.Shared.EntityBase;

public interface IEntityBase<TPrimaryKey>
{
    [Key]
    public TPrimaryKey Id { get; set; }
}