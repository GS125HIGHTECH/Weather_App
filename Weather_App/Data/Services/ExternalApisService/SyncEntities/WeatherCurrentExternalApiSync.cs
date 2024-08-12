﻿using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Weather_App.Consts;
using Weather_App.Data.Repositories.Base;
using Weather_App.Data.Repositories.Custom;
using Weather_App.Models.Entities;
using Weather_App.Models.ExternalApi.WeatherCurrent;

namespace Weather_App.Data.Services.ExternalApisService.SyncEntities;

public class WeatherCurrentExternalApiSync : ExternalApiSyncService<long, WeatherCurrent, WeatherCurrent>,
    IExternalApiSyncService<long, WeatherCurrent, WeatherCurrent>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WeatherCurrentExternalApiSync(
    ICustomRepository customRepository,
    IConfiguration configuration,
    IHttpClientFactory httpClientFactory,
    ILogger<ExternalApiSyncService<long, WeatherCurrent, WeatherCurrent>> logger,
    IEntityBaseRepository<long, WeatherCurrent> entityBaseRepository,
    UserManager<IdentityUser> userManager,
    IHttpContextAccessor httpContextAccessor)
    : base(customRepository, configuration, httpClientFactory, logger, entityBaseRepository)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<WeatherCurrent>> BeginRequest(string? parameters)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(parameters))
            {
                RequestInfo.Status = Statuses.Ok;

                var ret = await BeginRequest<ApiWeatherRealtime>(parameters,
                    async apiResult => await AdditionalOperation(apiResult));

                await SaveRequestInformation();

                return ret;
            }

            return new List<WeatherCurrent>();
        }
        catch (Exception ex)
        {
            RequestInfo.Description += "Error: " + ex.Message;
            RequestInfo.AdditionalInformations += "Error: " + ex.InnerException?.Message;
            RequestInfo.Status = Statuses.Error;
            await SaveRequestInformation();
            throw;
        }
    }

    private async Task<IEnumerable<WeatherCurrent>> AdditionalOperation(ApiWeatherRealtime apiResult)
    {
        var ret = new List<WeatherCurrent>();
        var createCounts = new Dictionary<string, int> { ["creatingWeatherCurrents"] = 0 };
        var createdWeatherCurrents = new List<WeatherCurrent>();

        if (apiResult != null)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            if (user != null)
            {
                var creatingWeatherCurrent = new WeatherCurrent
                {
                    AccountId = user.Id,
                    Location = new Location
                    {
                        Name = apiResult.Location?.Name,
                        Region = apiResult.Location?.Region,
                        Country = apiResult.Location?.Country,
                        Latitude = apiResult.Location?.Latitude,
                        Longitude = apiResult.Location?.Longitude,
                        TimeZone = apiResult.Location?.TimeZone,
                        LocaltimeEpoch = apiResult.Location?.LocaltimeEpoch,
                        Localtime = apiResult.Location?.Localtime
                    },
                    Current = new Current
                    {
                        LastUpdatedEpoch = apiResult.Current?.LastUpdatedEpoch,
                        LastUpdated = apiResult.Current?.LastUpdated,
                        TemperatureCelsius = apiResult.Current?.TemperatureCelsius,
                        TemperatureFahrenheit = apiResult.Current?.TemperatureFahrenheit,
                        IsDay = apiResult.Current?.IsDay,
                        WindMPH = apiResult.Current?.WindMPH,
                        WindKPH = apiResult.Current?.WindKPH,
                        WindDegree = apiResult.Current?.WindDegree,
                        WindDirection = apiResult.Current?.WindDirection,
                        PressureMilibars = apiResult.Current?.PressureMilibars,
                        PressureHgInches = apiResult.Current?.PressureHgInches,
                        PrecipMillimetres = apiResult.Current?.PrecipMillimetres,
                        PrecipInches = apiResult.Current?.PrecipInches,
                        Humidity = apiResult.Current?.Humidity,
                        Cloud = apiResult.Current?.Cloud,
                        FeelsLikeTemperatureCelsius = apiResult.Current?.FeelsLikeTemperatureCelsius,
                        FeelsLikeTemperatureFahrenheit = apiResult.Current?.FeelsLikeTemperatureFahrenheit,
                        WindChillCelsius = apiResult.Current?.WindChillCelsius,
                        WindChillFahrenheit = apiResult.Current?.WindChillFahrenheit,
                        HeatIndexCelsius = apiResult.Current?.HeatIndexCelsius,
                        HeatIndexFahrenheit = apiResult.Current?.HeatIndexFahrenheit,
                        DewpointCelsius = apiResult.Current?.DewpointCelsius,
                        DewpointFahrenheit = apiResult.Current?.DewpointFahrenheit,
                        VisibilityKilometers = apiResult.Current?.VisibilityKilometers,
                        VisibilityMiles = apiResult.Current?.VisibilityMiles,
                        UVIndex = apiResult.Current?.UVIndex,
                        GustMPH = apiResult.Current?.GustMPH,
                        GustKPH = apiResult.Current?.GustKPH,
                        Condition = apiResult.Current?.Condition != null ? new Condition
                        {
                            Text = apiResult.Current.Condition.Text,
                            Icon = apiResult.Current.Condition.Icon,
                            Code = apiResult.Current.Condition.Code
                        } : null
                    }
                };

                RequestInfo.AdditionalEntities = $"{Entities.Current}, {Entities.Location}";

                createdWeatherCurrents.Add(creatingWeatherCurrent);
                createCounts["creatingWeatherCurrents"]++;
            }
        }

        await CustomRepository.CreateOrUpdateMultiAsync<long, WeatherCurrent>(createdWeatherCurrents);

        RequestInfo.Description += $@"
            Created WeatherCurrents: {createCounts["creatingWeatherCurrents"]}.";

        return ret;
    }
}