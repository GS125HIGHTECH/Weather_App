using WeatherApp.Data.Repositories.Base;
using WeatherApp.Data.Repositories.Crud;
using WeatherApp.Data.Repositories.Custom;
using WeatherApp.Data.Repositories.Dto;
using WeatherApp.Data.Services.ExternalApisService;
using WeatherApp.Data.Services.ExternalApisService.SyncEntities;
using WeatherApp.Data.Services.WeatherCurrentService;
using WeatherApp.Data.Services.WeatherForecastService;
using WeatherApp.Shared.Models.Entities;
using WeatherApp.Shared.Models.Dto;

namespace WeatherApp.Config
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

            // ==== services ====
            builder.Services.AddScoped<IWeatherCurrentService, WeatherCurrentService>();
            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            builder.Services.AddTransient(typeof(IExternalApiSyncService<long, WeatherCurrent, WeatherCurrent>), typeof(WeatherCurrentExternalApiSync));
            builder.Services.AddTransient(typeof(IExternalApiSyncService<long, WeatherForecast, WeatherForecast>), typeof(WeatherForecastExternalApiSync));

            // ==== repositories ====
            builder.Services.AddScoped(typeof(IEntityBaseRepository<,>), typeof(EntityBaseRepository<,>));
            builder.Services.AddScoped(typeof(IEntityDtoRepository<,,>), typeof(EntityDtoRepository<,,>));
            builder.Services.AddScoped(typeof(ICrudRepository<,,,,>), typeof(CrudRepository<,,,,>));
            builder.Services.AddScoped<ICustomRepository, CustomRepository>();
        }
    }
}
