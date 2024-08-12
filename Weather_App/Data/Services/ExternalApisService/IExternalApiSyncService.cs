using Weather_App.Models.Entities.Shared.EntityBase;

namespace Weather_App.Data.Services.ExternalApisService;
public interface IExternalApiSyncService<TPrimaryKey, TEntityBase, TEndPointEntity>
    where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
{
    Task<(IEnumerable<TEntityBase> Results, int Pages)> BeginRequest(string? parameters);
}
