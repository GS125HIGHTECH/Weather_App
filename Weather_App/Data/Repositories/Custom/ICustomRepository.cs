using Weather_App.Models.Dto.Shared.EntityDto;
using Weather_App.Models.Entities.Shared.EntityBase;
using System.Linq.Expressions;

namespace Weather_App.Data.Repositories.Custom;
public interface ICustomRepository
{
    TEntityBase GetById<TPrimaryKey, TEntityBase>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    Task<TEntityBase> GetByIdAsync<TPrimaryKey, TEntityBase>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    TEntityDto GetById<TPrimaryKey, TEntityBase, TEntityDto>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    Task<TEntityDto> GetByIdAsync<TPrimaryKey, TEntityBase, TEntityDto>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    IEnumerable<TEntityBase> GetWhere<TPrimaryKey, TEntityBase>(Expression<Func<TEntityBase, bool>> predicate)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    Task<IEnumerable<TEntityBase>> GetWhereAsync<TPrimaryKey, TEntityBase>(Expression<Func<TEntityBase, bool>> predicate)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    IEnumerable<TEntityDto> GetWhere<TPrimaryKey, TEntityBase, TEntityDto>(Expression<Func<TEntityBase, bool>> predicate)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    Task<IEnumerable<TEntityDto>> GetWhereAsync<TPrimaryKey, TEntityBase, TEntityDto>(Expression<Func<TEntityBase, bool>> predicate)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    IQueryable<TEntityBase> GetQuery<TPrimaryKey, TEntityBase>(Func<IQueryable<TEntityBase>, IQueryable<TEntityBase>> queryBuilder)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    IQueryable<TEntityDto> GetQuery<TPrimaryKey, TEntityBase, TEntityDto>(Func<IQueryable<TEntityBase>, IQueryable<TEntityBase>> queryBuilder)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    public IQueryable<TReturn> GetQuery<TPrimaryKey, TEntityBase, TReturn>(Func<IQueryable<TEntityBase>, IQueryable<TReturn>> queryBuilder)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TReturn : class, new();

    IEnumerable<TEntityBase> GetAll<TPrimaryKey, TEntityBase>()
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    Task<IEnumerable<TEntityBase>> GetAllAsync<TPrimaryKey, TEntityBase>()
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    IEnumerable<TEntityDto> GetAll<TPrimaryKey, TEntityBase, TEntityDto>()
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    Task<IEnumerable<TEntityDto>> GetAllAsync<TPrimaryKey, TEntityBase, TEntityDto>()
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    TEntityBase Create<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    Task<TEntityBase> CreateAsync<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    TEntityDto Create<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    Task<TEntityDto> CreateAsync<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    Task<IEnumerable<TEntityBase>> CreateOrUpdateMultiAsync<TPrimaryKey, TEntityBase>(IEnumerable<TEntityBase> entities)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    TEntityBase Update<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    Task<TEntityBase> UpdateAsync<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    TEntityDto Update<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    Task<TEntityDto> UpdateAsync<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    void Delete<TPrimaryKey, TEntityBase>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    Task DeleteAsync<TPrimaryKey, TEntityBase>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    void Delete<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    Task DeleteAsync<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new();

    void Delete<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();

    Task DeleteAsync<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new();
}