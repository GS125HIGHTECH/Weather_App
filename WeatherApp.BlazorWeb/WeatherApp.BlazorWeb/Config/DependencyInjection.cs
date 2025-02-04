using WeatherApp.BlazorWeb.Data.Repositories.Base;
using WeatherApp.BlazorWeb.Data.Repositories.Crud;
using WeatherApp.BlazorWeb.Data.Repositories.Custom;
using WeatherApp.BlazorWeb.Data.Repositories.Dto;
using WeatherApp.BlazorWeb.Data.Services.ExternalApisService.SyncEntities;
using WeatherApp.BlazorWeb.Data.Services.WeatherCurrentService;
using WeatherApp.BlazorWeb.Data.Services.WeatherForecastService;
using WeatherApp.BlazorWeb.Models.Entities;
using WeatherApp.Shared.Data.Repositories.Base;
using WeatherApp.Shared.Data.Repositories.Crud;
using WeatherApp.Shared.Data.Repositories.Custom;
using WeatherApp.Shared.Data.Repositories.Dto;
using WeatherApp.Shared.Data.Services.ExternalApisService;
using WeatherApp.Shared.Data.Services.WeatherCurrentService;
using WeatherApp.Shared.Data.Services.WeatherForecastService;
using WeatherApp.Shared.Models.Dto;

namespace WeatherApp.BlazorWeb.Config
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

            builder.Services.AddTransient(typeof(IExternalApiSyncService<long, WeatherCurrentBlazor, WeatherCurrentBlazor>), typeof(WeatherCurrentExternalApiSync));
            builder.Services.AddTransient(typeof(IExternalApiSyncService<long, WeatherForecastBlazor, WeatherForecastBlazor>), typeof(WeatherForecastExternalApiSync));

            // ==== repositories ====
            builder.Services.AddScoped(typeof(IEntityBaseRepository<,>), typeof(EntityBaseRepository<,>));
            builder.Services.AddScoped(typeof(IEntityDtoRepository<,,>), typeof(EntityDtoRepository<,,>));
            builder.Services.AddScoped(typeof(ICrudRepository<,,,,>), typeof(CrudRepository<,,,,>));
            builder.Services.AddScoped<ICustomRepository, CustomRepository>();
        }
    }
}
