using Weather_App.Models.Dto.Shared.EntityDto;
using Weather_App.Models.Entities.Shared.EntityBase;
using System.Linq.Expressions;

namespace Weather_App.Data.Repositories.Dto;

public interface IEntityDtoRepository<TPrimaryKey, TEntityBase, TEntityDto>
    where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
{
    TEntityDto GetById(TPrimaryKey id);

    Task<TEntityDto> GetByIdAsync(TPrimaryKey id);

    IEnumerable<TEntityDto> GetWhere(Expression<Func<TEntityBase, bool>> predicate);

    Task<IEnumerable<TEntityDto>> GetWhereAsync(Expression<Func<TEntityBase, bool>> predicate);

    IQueryable<TEntityDto> GetQuery(Func<IQueryable<TEntityBase>, IQueryable<TEntityBase>> queryBuilder);

    IEnumerable<TEntityDto> GetAll();

    Task<IEnumerable<TEntityDto>> GetAllAsync();

    TEntityDto Create(TEntityDto entity);

    Task<TEntityDto> CreateAsync(TEntityDto entity);

    TEntityDto Update(TEntityDto entity);

    Task<TEntityDto> UpdateAsync(TEntityDto entity);

    void Delete(TPrimaryKey id);

    Task DeleteAsync(TPrimaryKey id);

    void Delete(TEntityDto entity);

    Task DeleteAsync(TEntityDto entity);
}
