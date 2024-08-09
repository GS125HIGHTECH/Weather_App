using Weather_App.Models.Entities.Shared.EntityBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Weather_App.Data.Repositories.Base;

public class EntityBaseRepository<TPrimaryKey, TEntityBase> : IEntityBaseRepository<TPrimaryKey, TEntityBase>
    where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
{
    private readonly ApplicationDbContext _context;

    public EntityBaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public TEntityBase GetById(TPrimaryKey id)
    {
        var entity = _context.Set<TEntityBase>().Find(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        return entity;
    }

    public async Task<TEntityBase> GetByIdAsync(TPrimaryKey id)
    {
        var entity = await _context.Set<TEntityBase>().FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        return entity;
    }

    public IEnumerable<TEntityBase> GetWhere(Expression<Func<TEntityBase, bool>> predicate)
    {
        return _context.Set<TEntityBase>().Where(predicate).ToList();
    }

    public async Task<IEnumerable<TEntityBase>> GetWhereAsync(Expression<Func<TEntityBase, bool>> predicate)
    {
        return await _context.Set<TEntityBase>().Where(predicate).ToListAsync();
    }

    public IQueryable<TEntityBase> GetQuery(Func<IQueryable<TEntityBase>, IQueryable<TEntityBase>> queryBuilder)
    {
        var query = _context.Set<TEntityBase>().AsQueryable();
        return queryBuilder(query);
    }

    public IEnumerable<TEntityBase> GetAll()
    {
        return _context.Set<TEntityBase>().ToList();
    }

    public async Task<IEnumerable<TEntityBase>> GetAllAsync()
    {
        return await _context.Set<TEntityBase>().ToListAsync();
    }

    public TEntityBase Create(TEntityBase entity)
    {
        var entityEntry = _context.Set<TEntityBase>().Add(entity);
        _context.SaveChanges();

        return entityEntry.Entity;
    }

    public async Task<TEntityBase> CreateAsync(TEntityBase entity)
    {
        var entityEntry = await _context.Set<TEntityBase>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<IEnumerable<TEntityBase>> CreateMultiAsync(IEnumerable<TEntityBase> entities)
    {
        var entries = new List<EntityEntry<TEntityBase>>();
        foreach (var entity in entities)
        {
            var entityEntry = await _context.Set<TEntityBase>().AddAsync(entity);
            entries.Add(entityEntry);
        }
        
        await _context.SaveChangesAsync();

        return entries.Select(e => e.Entity);
    }

    public async Task<IEnumerable<TEntityBase>> CreateOrUpdateMultiAsync(IEnumerable<TEntityBase> entities)
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

    public TEntityBase Update(TEntityBase entity)
    {
        var entityEntry = _context.Set<TEntityBase>().Update(entity);
        _context.SaveChanges();

        return entityEntry.Entity;
    }

    public async Task<TEntityBase> UpdateAsync(TEntityBase entity)
    {
        var entityEntry = _context.Set<TEntityBase>().Update(entity);
        await _context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<IEnumerable<TEntityBase>> UpdateMultiAsync(IEnumerable<TEntityBase> entities)
    {
        var entries = new List<EntityEntry<TEntityBase>>();
        foreach (var entity in entities)
        {
            var entityEntry = _context.Set<TEntityBase>().Update(entity);
            entries.Add(entityEntry);
        }

        await _context.SaveChangesAsync();

        return entries.Select(e => e.Entity);
    }

    public void Delete(TPrimaryKey id)
    {
        var entity = _context.Set<TEntityBase>().Find(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        _context.Set<TEntityBase>().Remove(entity);
        _context.SaveChanges();
    }

    public async Task DeleteAsync(TPrimaryKey id)
    {
        var entity = await _context.Set<TEntityBase>().FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        _context.Set<TEntityBase>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public void Delete(TEntityBase entity)
    {
        _context.Set<TEntityBase>().Remove(entity);
        _context.SaveChanges();
    }

    public async Task DeleteAsync(TEntityBase entity)
    {
        _context.Set<TEntityBase>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}