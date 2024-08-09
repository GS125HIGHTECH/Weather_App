using Weather_App.Models.Dto;

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
        }
    }
}
