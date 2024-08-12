using Weather_App.Data.Repositories.Base;
using Weather_App.Data.Repositories.Crud;
using Weather_App.Data.Repositories.Custom;
using Weather_App.Data.Repositories.Dto;
using Weather_App.Data.Services.ExternalApisService;
using Weather_App.Data.Services.ExternalApisService.SyncEntities;
using Weather_App.Models.Dto;
using Weather_App.Models.Entities;

namespace Weather_App.Config
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            var externalApisConfig = builder.Configuration.GetSection("ExternalApis").Get<Dictionary<string, ExternalApiConfig>>();
            foreach (var apiConfig in externalApisConfig)
            {
                var config = apiConfig.Value;
                builder.Services.AddHttpClient(apiConfig.Key, client =>
                {
                    client.BaseAddress = config.Url;
                    client.DefaultRequestHeaders.Add("x-rapidapi-key", config.Key);
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", config.Address);
                });
            }

            // ==== repositories ====
            builder.Services.AddScoped(typeof(IEntityBaseRepository<,>), typeof(EntityBaseRepository<,>));
            builder.Services.AddScoped(typeof(IEntityDtoRepository<,,>), typeof(EntityDtoRepository<,,>));
            builder.Services.AddScoped(typeof(ICrudRepository<,,,,>), typeof(CrudRepository<,,,,>));
            builder.Services.AddScoped<ICustomRepository, CustomRepository>();

            builder.Services.AddTransient(typeof(IExternalApiSyncService<long, WeatherCurrent, WeatherCurrent>), typeof(WeatherCurrentExternalApiSync));
            builder.Services.AddTransient(typeof(IExternalApiSyncService<long, WeatherForecast, WeatherForecast>), typeof(WeatherForecastExternalApiSync));
        }
    }
}
