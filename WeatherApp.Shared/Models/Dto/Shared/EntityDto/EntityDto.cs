namespace WeatherApp.Shared.Models.Dto.Shared.EntityDto;

public abstract class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }
}