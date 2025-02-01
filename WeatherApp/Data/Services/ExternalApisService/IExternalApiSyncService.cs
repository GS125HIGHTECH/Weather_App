using WeatherApp.Shared.Models.Entities.Shared.EntityBase;

namespace WeatherApp.Data.Services.ExternalApisService;
public interface IExternalApiSyncService<TPrimaryKey, TEntityBase, TEndPointEntity>
    where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
{
    Task<IEnumerable<TEntityBase>> BeginRequest(string? parameters);
}
