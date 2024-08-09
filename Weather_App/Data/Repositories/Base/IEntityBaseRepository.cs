using Weather_App.Models.Entities.Shared.EntityBase;
using System.Linq.Expressions;

namespace Weather_App.Data.Repositories.Base;

public interface IEntityBaseRepository<TPrimaryKey, TEntityBase>
    where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
{
    TEntityBase GetById(TPrimaryKey id);

    Task<TEntityBase> GetByIdAsync(TPrimaryKey id);

    IEnumerable<TEntityBase> GetWhere(Expression<Func<TEntityBase, bool>> predicate);

    Task<IEnumerable<TEntityBase>> GetWhereAsync(Expression<Func<TEntityBase, bool>> predicate);

    IQueryable<TEntityBase> GetQuery(Func<IQueryable<TEntityBase>, IQueryable<TEntityBase>> queryBuilder);

    IEnumerable<TEntityBase> GetAll();

    Task<IEnumerable<TEntityBase>> GetAllAsync();

    TEntityBase Create(TEntityBase entity);

    Task<TEntityBase> CreateAsync(TEntityBase entity);

    Task<IEnumerable<TEntityBase>> CreateMultiAsync(IEnumerable<TEntityBase> entities);

    Task<IEnumerable<TEntityBase>> CreateOrUpdateMultiAsync(IEnumerable<TEntityBase> entities);

    TEntityBase Update(TEntityBase entity);

    Task<TEntityBase> UpdateAsync(TEntityBase entity);

    Task<IEnumerable<TEntityBase>> UpdateMultiAsync(IEnumerable<TEntityBase> entities);

    void Delete(TPrimaryKey id);

    Task DeleteAsync(TPrimaryKey id);

    void Delete(TEntityBase entity);

    Task DeleteAsync(TEntityBase entity);
}
