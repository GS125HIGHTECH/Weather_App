namespace Weather_App.Models.Dto.Shared.EntityDto;

public abstract class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }
}