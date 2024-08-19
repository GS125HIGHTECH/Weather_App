namespace Weather_App.Models.Dto.Shared.EntityDto;

public interface IEntityDto<TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }
}