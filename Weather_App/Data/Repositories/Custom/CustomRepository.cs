using AutoMapper;
using Weather_App.Models.Dto.Shared.EntityDto;
using Weather_App.Models.Entities.Shared.EntityBase;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Weather_App.Data.Repositories.Custom;

public class CustomRepository : ICustomRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CustomRepository(
        ApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public TEntityBase GetById<TPrimaryKey, TEntityBase>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var entity = _context.Set<TEntityBase>().Find(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        return entity;
    }

    public async Task<TEntityBase> GetByIdAsync<TPrimaryKey, TEntityBase>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var entity = await _context.Set<TEntityBase>().FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        return entity;
    }

    public TEntityDto GetById<TPrimaryKey, TEntityBase, TEntityDto>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var entity = _context.Set<TEntityBase>().Find(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        return _mapper.Map<TEntityDto>(entity);
    }

    public async Task<TEntityDto> GetByIdAsync<TPrimaryKey, TEntityBase, TEntityDto>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var entity = await _context.Set<TEntityBase>().FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        return _mapper.Map<TEntityDto>(entity);
    }

    public IEnumerable<TEntityBase> GetWhere<TPrimaryKey, TEntityBase>(Expression<Func<TEntityBase, bool>> predicate)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        return _context.Set<TEntityBase>().Where(predicate).ToList();
    }

    public async Task<IEnumerable<TEntityBase>> GetWhereAsync<TPrimaryKey, TEntityBase>(Expression<Func<TEntityBase, bool>> predicate)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        return await _context.Set<TEntityBase>().Where(predicate).ToListAsync();
    }
    
    public IEnumerable<TEntityDto> GetWhere<TPrimaryKey, TEntityBase, TEntityDto>(Expression<Func<TEntityBase, bool>> predicate)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var entities = _context.Set<TEntityBase>().Where(predicate).ToList();
        return _mapper.Map<IEnumerable<TEntityDto>>(entities);
    }

    public async Task<IEnumerable<TEntityDto>> GetWhereAsync<TPrimaryKey, TEntityBase, TEntityDto>(Expression<Func<TEntityBase, bool>> predicate)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var entities = await _context.Set<TEntityBase>().Where(predicate).ToListAsync();
        return _mapper.Map<IEnumerable<TEntityDto>>(entities);
    }

    public IQueryable<TEntityBase> GetQuery<TPrimaryKey, TEntityBase>(Func<IQueryable<TEntityBase>, IQueryable<TEntityBase>> queryBuilder)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var query = _context.Set<TEntityBase>().AsQueryable();
        return queryBuilder(query);
    }

    public IQueryable<TEntityDto> GetQuery<TPrimaryKey, TEntityBase, TEntityDto>(Func<IQueryable<TEntityBase>, IQueryable<TEntityBase>> queryBuilder)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var query = _context.Set<TEntityBase>().AsQueryable();
        query = queryBuilder(query);

        return query.Select(entity => _mapper.Map<TEntityDto>(entity));
    }

    public IQueryable<TReturn> GetQuery<TPrimaryKey, TEntityBase, TReturn>(Func<IQueryable<TEntityBase>, IQueryable<TReturn>> queryBuilder)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TReturn : class, new()
    {
        var query = _context.Set<TEntityBase>().AsQueryable();
        return queryBuilder(query);
    }

    public IEnumerable<TEntityBase> GetAll<TPrimaryKey, TEntityBase>()
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        return _context.Set<TEntityBase>().ToList();
    }

    public async Task<IEnumerable<TEntityBase>> GetAllAsync<TPrimaryKey, TEntityBase>()
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        return await _context.Set<TEntityBase>().ToListAsync();
    }

    public IEnumerable<TEntityDto> GetAll<TPrimaryKey, TEntityBase, TEntityDto>()
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var entities = _context.Set<TEntityBase>().ToList();
        return _mapper.Map<IEnumerable<TEntityDto>>(entities);
    }

    public async Task<IEnumerable<TEntityDto>> GetAllAsync<TPrimaryKey, TEntityBase, TEntityDto>()
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var entities = await _context.Set<TEntityBase>().ToListAsync();
        return _mapper.Map<IEnumerable<TEntityDto>>(entities);
    }

    public TEntityBase Create<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var entityEntry = _context.Set<TEntityBase>().Add(entity);
        _context.SaveChanges();

        return entityEntry.Entity;
    }

    public async Task<TEntityBase> CreateAsync<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var entityEntry = await _context.Set<TEntityBase>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public TEntityDto Create<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var entityEntry = _context.Set<TEntityBase>().Add(_mapper.Map<TEntityBase>(entity));
        _context.SaveChanges();

        return _mapper.Map<TEntityDto>(entityEntry.Entity);
    }

    public async Task<TEntityDto> CreateAsync<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var entityEntry = await _context.Set<TEntityBase>().AddAsync(_mapper.Map<TEntityBase>(entity));
        await _context.SaveChangesAsync();

        return _mapper.Map<TEntityDto>(entityEntry.Entity);
    }

    public async Task<IEnumerable<TEntityBase>> CreateOrUpdateMultiAsync<TPrimaryKey, TEntityBase>(IEnumerable<TEntityBase> entities)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var addEntities = new List<TEntityBase>();
        var updateEntities = new List<TEntityBase>();

        foreach (var entity in entities)
        {
            if (EqualityComparer<TPrimaryKey>.Default.Equals(entity.Id, default))
                addEntities.Add(entity);
            else
                updateEntities.Add(entity);
        }

        if (addEntities.Any())
            await _context.Set<TEntityBase>().AddRangeAsync(addEntities);

        if (updateEntities.Any())
            _context.Set<TEntityBase>().UpdateRange(updateEntities);

        await _context.SaveChangesAsync();

        return addEntities.Concat(updateEntities);
    }

    public TEntityBase Update<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var entityEntry = _context.Set<TEntityBase>().Update(entity);
        _context.SaveChanges();

        return entityEntry.Entity;
    }

    public async Task<TEntityBase> UpdateAsync<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var entityEntry = _context.Set<TEntityBase>().Update(entity);
        await _context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public TEntityDto Update<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var existingEntity = _context.Set<TEntityBase>().Find(entity.Id);
        if (existingEntity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {entity.Id} was not found.");

        var updateType = typeof(TEntityDto);
        var entityType = typeof(TEntityBase);
        var entityProperties = entityType.GetProperties().ToList();

        foreach (var updateProp in updateType.GetProperties())
        {
            var newVal = updateProp.GetValue(entity);
            var entProp = entityProperties.Single(item => item.Name == updateProp.Name);
            entProp.SetValue(existingEntity, newVal);
        }

        var entityEntry = _context.Set<TEntityBase>().Update(existingEntity);
        _context.SaveChanges();

        return _mapper.Map<TEntityDto>(entityEntry.Entity);
    }

    public async Task<TEntityDto> UpdateAsync<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        var existingEntity = await _context.Set<TEntityBase>().FindAsync(entity.Id);
        if (existingEntity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {entity.Id} was not found.");

        var updateType = typeof(TEntityDto);
        var entityType = typeof(TEntityBase);
        var entityProperties = entityType.GetProperties().ToList();

        foreach (var updateProp in updateType.GetProperties())
        {
            var newVal = updateProp.GetValue(entity);
            var entProp = entityProperties.Single(item => item.Name == updateProp.Name);
            entProp.SetValue(existingEntity, newVal);
        }

        var entityEntry = _context.Set<TEntityBase>().Update(existingEntity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TEntityDto>(entityEntry.Entity);
    }

    public void Delete<TPrimaryKey, TEntityBase>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var entity = _context.Set<TEntityBase>().Find(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        _context.Set<TEntityBase>().Remove(entity);
        _context.SaveChanges();
    }

    public async Task DeleteAsync<TPrimaryKey, TEntityBase>(TPrimaryKey id)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        var entity = await _context.Set<TEntityBase>().FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        _context.Set<TEntityBase>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public void Delete<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        _context.Set<TEntityBase>().Remove(entity);
        _context.SaveChanges();
    }

    public async Task DeleteAsync<TPrimaryKey, TEntityBase>(TEntityBase entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    {
        _context.Set<TEntityBase>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public void Delete<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        _context.Set<TEntityBase>().Remove(_mapper.Map<TEntityBase>(entity));
        _context.SaveChanges();
    }

    public async Task DeleteAsync<TPrimaryKey, TEntityBase, TEntityDto>(TEntityDto entity)
        where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
        where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    {
        _context.Set<TEntityBase>().Remove(_mapper.Map<TEntityBase>(entity));
        await _context.SaveChangesAsync();
    }
}
