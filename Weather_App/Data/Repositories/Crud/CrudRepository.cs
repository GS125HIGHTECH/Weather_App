using AutoMapper;
using Weather_App.Models.Dto.Shared.EntityDto;
using Weather_App.Models.Entities.Shared.EntityBase;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Weather_App.Data.Repositories.Crud;

public class CrudRepository<TPrimaryKey, TEntityBase, TEntityDto, TUpdateDto, TCreateDto> 
    : ICrudRepository<TPrimaryKey, TEntityBase, TEntityDto, TUpdateDto, TCreateDto>
    where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
    where TEntityDto : class, IEntityDto<TPrimaryKey>, new()
    where TUpdateDto : class, IEntityDto<TPrimaryKey>, new()
    where TCreateDto : class, new()
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CrudRepository(
        ApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public TEntityDto GetById(TPrimaryKey id)
    {
        var entity = _context.Set<TEntityBase>().Find(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        return _mapper.Map<TEntityDto>(entity);
    }

    public async Task<TEntityDto> GetByIdAsync(TPrimaryKey id)
    {
        var entity = await _context.Set<TEntityBase>().FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {id} was not found.");

        return _mapper.Map<TEntityDto>(entity);
    }

    public IEnumerable<TEntityDto> GetWhere(Expression<Func<TEntityBase, bool>> predicate)
    {
        var entities = _context.Set<TEntityBase>().Where(predicate).ToList();
        return _mapper.Map<IEnumerable<TEntityDto>>(entities);
    }

    public async Task<IEnumerable<TEntityDto>> GetWhereAsync(Expression<Func<TEntityBase, bool>> predicate)
    {
        var entities = await _context.Set<TEntityBase>().Where(predicate).ToListAsync();
        return _mapper.Map<IEnumerable<TEntityDto>>(entities);
    }

    public IQueryable<TEntityDto> GetQuery(Func<IQueryable<TEntityBase>, IQueryable<TEntityBase>> queryBuilder)
    {
        var query = _context.Set<TEntityBase>().AsQueryable();
        query = queryBuilder(query);

        return query.Select(entity => _mapper.Map<TEntityDto>(entity));
    }

    public IEnumerable<TEntityDto> GetAll()
    {
        var entities = _context.Set<TEntityBase>().ToList();
        return _mapper.Map<IEnumerable<TEntityDto>>(entities);
    }

    public async Task<IEnumerable<TEntityDto>> GetAllAsync()
    {
        var entities = await _context.Set<TEntityBase>().ToListAsync();
        return _mapper.Map<IEnumerable<TEntityDto>>(entities);
    }

    public TEntityDto Create(TCreateDto entity)
    {
        var entityEntry = _context.Set<TEntityBase>().Add(_mapper.Map<TEntityBase>(entity));
        _context.SaveChanges();

        return _mapper.Map<TEntityDto>(entityEntry.Entity);
    }

    public async Task<TEntityDto> CreateAsync(TCreateDto entity)
    {
        var entityEntry = await _context.Set<TEntityBase>().AddAsync(_mapper.Map<TEntityBase>(entity));
        await _context.SaveChangesAsync();

        return _mapper.Map<TEntityDto>(entityEntry.Entity);
    }


    public async Task<IEnumerable<TEntityDto>> CreateOrUpdateMultiAsync(IEnumerable<TEntityBase> entities)
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

        return _mapper.Map<IEnumerable<TEntityDto>>(addEntities.Concat(updateEntities));
    }

    public async Task<IEnumerable<TEntityDto>> CreateOrUpdateMultiAsync(IEnumerable<TEntityDto> entities)
    {
        var addEntities = new List<TEntityBase>();
        var updateEntities = new List<TEntityBase>();

        foreach (var item in entities)
        {
            if (EqualityComparer<TPrimaryKey>.Default.Equals(item.Id, default))
                addEntities.Add(_mapper.Map<TEntityBase>(item));
            else
            {
                var existingEntity = _context.Set<TEntityBase>().Find(item.Id);

                var updateType = typeof(TEntityDto);
                var entityType = typeof(TEntityBase);
                var entityProperties = entityType.GetProperties().ToList();
                
                foreach (var updateProp in updateType.GetProperties())
                {
                    var newVal = updateProp.GetValue(item);
                    var entProp = entityProperties.Single(item => item.Name == updateProp.Name);
                    entProp.SetValue(existingEntity, newVal);
                }

                updateEntities.Add(existingEntity);
            }
        }

        if (addEntities.Any())
            await _context.Set<TEntityBase>().AddRangeAsync(addEntities);

        if (updateEntities.Any())
            _context.Set<TEntityBase>().UpdateRange(updateEntities);

        await _context.SaveChangesAsync();

        return _mapper.Map<IEnumerable<TEntityDto>>(addEntities.Concat(updateEntities));
    }

    public TEntityDto Update(TUpdateDto entity)
    {
        var existingEntity = _context.Set<TEntityBase>().Find(entity.Id);
        if (existingEntity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {entity.Id} was not found.");

        var updateType = typeof(TUpdateDto);
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

    public async Task<TEntityDto> UpdateAsync(TUpdateDto entity)
    {
        var existingEntity = await _context.Set<TEntityBase>().FindAsync(entity.Id);
        if (existingEntity == null)
            throw new KeyNotFoundException($"Entity of type {typeof(TEntityBase).FullName} with ID {entity.Id} was not found.");

        var updateType = typeof(TUpdateDto);
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

    public void Delete(TEntityDto entity)
    {
        _context.Set<TEntityBase>().Remove(_mapper.Map<TEntityBase>(entity));
        _context.SaveChanges();
    }

    public async Task DeleteAsync(TEntityDto entity)
    {
        _context.Set<TEntityBase>().Remove(_mapper.Map<TEntityBase>(entity));
        await _context.SaveChangesAsync();
    }
}
