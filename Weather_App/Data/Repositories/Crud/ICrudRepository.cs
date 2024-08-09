using System.Linq.Expressions;

namespace Weather_App.Data.Repositories.Crud;

public interface ICrudRepository<TPrimaryKey, TEntityBase, TEntityDto, TUpdateDto, TCreateDto>
{
    TEntityDto GetById(TPrimaryKey id);

    Task<TEntityDto> GetByIdAsync(TPrimaryKey id);

    IEnumerable<TEntityDto> GetWhere(Expression<Func<TEntityBase, bool>> predicate);

    Task<IEnumerable<TEntityDto>> GetWhereAsync(Expression<Func<TEntityBase, bool>> predicate);

    IQueryable<TEntityDto> GetQuery(Func<IQueryable<TEntityBase>, IQueryable<TEntityBase>> queryBuilder);

    IEnumerable<TEntityDto> GetAll();

    Task<IEnumerable<TEntityDto>> GetAllAsync();

    TEntityDto Create(TCreateDto entity);

    Task<TEntityDto> CreateAsync(TCreateDto entity);

    Task<IEnumerable<TEntityDto>> CreateOrUpdateMultiAsync(IEnumerable<TEntityBase> entities);

    Task<IEnumerable<TEntityDto>> CreateOrUpdateMultiAsync(IEnumerable<TEntityDto> entities);

    TEntityDto Update(TUpdateDto entity);

    Task<TEntityDto> UpdateAsync(TUpdateDto entity);

    void Delete(TPrimaryKey id);

    Task DeleteAsync(TPrimaryKey id);

    void Delete(TEntityDto entity);

    Task DeleteAsync(TEntityDto entity);
}