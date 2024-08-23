using Microsoft.AspNetCore.Identity;
using Weather_App.Consts;
using Weather_App.Data.Repositories.Base;
using Weather_App.Data.Repositories.Custom;
using Weather_App.Models.Entities;
using Weather_App.Models.ExternalApi.WeatherForecast;

namespace Weather_App.Data.Services.ExternalApisService.SyncEntities;

public class WeatherForecastExternalApiSync : ExternalApiSyncService<long, WeatherForecast, WeatherForecast>,
IExternalApiSyncService<long, WeatherForecast, WeatherForecast>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WeatherForecastExternalApiSync(
    ICustomRepository customRepository,
    IConfiguration configuration,
    IHttpClientFactory httpClientFactory,
    ILogger<ExternalApiSyncService<long, WeatherForecast, WeatherForecast>> logger,
    IEntityBaseRepository<long, WeatherForecast> entityBaseRepository,
    UserManager<IdentityUser> userManager,
    IHttpContextAccessor httpContextAccessor)
    : base(customRepository, configuration, httpClientFactory, logger, entityBaseRepository)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<WeatherForecast>> BeginRequest(string? parameters)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(parameters))
            {
                RequestInfo.Status = Statuses.Ok;

                var ret = await BeginRequest<ApiWeatherForecast>(parameters,
                    async apiResult => await AdditionalOperation(apiResult));

                await SaveRequestInformation();

                return ret;
            }

            return new List<WeatherForecast>();
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

    private async Task<IEnumerable<WeatherForecast>> AdditionalOperation(ApiWeatherForecast apiResult)
    {
        var ret = new List<WeatherForecast>();
        var createCounts = new Dictionary<string, int> { ["creatingWeatherForecasts"] = 0, ["creatingForecastDays"] = 0 };
        var createdWeatherForecasts = new List<WeatherForecast>();
        
        if (apiResult != null && apiResult.Location != null && apiResult.Current?.Condition != null && apiResult.Forecast?.ForecastDays != null)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            if (user != null)
            {
                var creatingWeatherForecast = new WeatherForecast
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
                    },
                    ForecastDays = apiResult.Forecast?.ForecastDays?.Select(day => new ForecastDay
                    {
                        Date = day.Date,
                        DateEpoch = day.DateEpoch,
                        MaxTemperatureCelsius = day.Day?.MaxTemperatureCelsius,
                        MaxTemperatureFahrenheit = day.Day?.MaxTemperatureFahrenheit,
                        MinTemperatureCelsius = day.Day?.MinTemperatureCelsius,
                        MinTemperatureFahrenheit = day.Day?.MinTemperatureFahrenheit,
                        AvgTemperatureCelsius = day.Day?.AvgTemperatureCelsius,
                        AvgTemperatureFahrenheit = day.Day?.AvgTemperatureFahrenheit,
                        MaxWindMPH = day.Day?.MaxWindMPH,
                        MaxWindKPH = day.Day?.MaxWindKPH,
                        TotalPrecipMillimetres = day.Day?.TotalPrecipMillimetres,
                        TotalPrecipInches = day.Day?.TotalPrecipInches,
                        TotalSnowCentimeters = day.Day?.TotalSnowCentimeters,
                        AvgVisibilityKilometers = day.Day?.AvgVisibilityKilometers,
                        AvgVisibilityMiles = day.Day?.AvgVisibilityMiles,
                        AvgHumidity = day.Day?.AvgHumidity,
                        WillItRain = day.Day?.WillItRain ?? false,
                        ChanceOfRain = day.Day?.ChanceOfRain,
                        WillItSnow = day.Day?.WillItSnow ?? false,
                        ChanceOfSnow = day.Day?.ChanceOfSnow,
                        UVIndex = day.Day?.UVIndex,
                        Condition = day.Day?.Condition != null ? new Condition
                        {
                            Text = day.Day.Condition.Text,
                            Icon = day.Day.Condition.Icon,
                            Code = day.Day.Condition.Code
                        } : null,
                        Astro = day.Astro != null ? new Astro
                        {
                            Sunrise = day.Astro.Sunrise,
                            Sunset = day.Astro.Sunset,
                            Moonrise = day.Astro.Moonrise,
                            Moonset = day.Astro.Moonset,
                            MoonPhase = day.Astro.MoonPhase,
                            MoonIllumination = day.Astro.MoonIllumination,
                            IsMoonUp = day.Astro.IsMoonUp,
                            IsSunUp = day.Astro.IsSunUp
                        } : null,
                        ForecastHours = day.Hours?.Select(hour => new ForecastHour
                        {
                            TimeEpoch = hour.TimeEpoch,
                            Time = hour.Time,
                            TemperatureCelsius = hour.TemperatureCelsius,
                            TemperatureFahrenheit = hour.TemperatureFahrenheit,
                            IsDay = hour.IsDay,
                            WindMPH = hour.WindMPH,
                            WindKPH = hour.WindKPH,
                            WindDegree = hour.WindDegree,
                            WindDirection = hour.WindDirection,
                            PressureMilibars = hour.PressureMilibars,
                            PressureHgInches = hour.PressureHgInches,
                            PrecipMillimetres = hour.PrecipMillimetres,
                            PrecipInches = hour.PrecipInches,
                            SnowCentimeters = hour.SnowCentimeters,
                            Humidity = hour.Humidity,
                            Cloud = hour.Cloud,
                            FeelsLikeTemperatureCelsius = hour.FeelsLikeTemperatureCelsius,
                            FeelsLikeTemperatureFahrenheit = hour.FeelsLikeTemperatureFahrenheit,
                            WindChillCelsius = hour.WindChillCelsius,
                            WindChillFahrenheit = hour.WindChillFahrenheit,
                            HeatIndexCelsius = hour.HeatIndexCelsius,
                            HeatIndexFahrenheit = hour.HeatIndexFahrenheit,
                            DewpointCelsius = hour.DewpointCelsius,
                            DewpointFahrenheit = hour.DewpointFahrenheit,
                            VisibilityKilometers = hour.VisibilityKilometers,
                            VisibilityMiles = hour.VisibilityMiles,
                            GustMPH = hour.GustMPH,
                            GustKPH = hour.GustKPH,
                            UVIndex = hour.UVIndex,
                            Condition = hour.Condition != null ? new Condition
                            {
                                Text = hour.Condition.Text,
                                Icon = hour.Condition.Icon,
                                Code = hour.Condition.Code
                            } : null
                        }).ToList()
                    }).ToList()
                };

                RequestInfo.AdditionalEntities = $"{Entities.Current}, {Entities.Location}, {Entities.ForecastDay}";

                createdWeatherForecasts.Add(creatingWeatherForecast);
                createCounts["creatingWeatherForecasts"]++;
                createCounts["creatingForecastDays"] += creatingWeatherForecast.ForecastDays?.Count ?? 0;
            }

            await CustomRepository.CreateOrUpdateMultiAsync<long, WeatherForecast>(createdWeatherForecasts);

            RequestInfo.Description += $@"
            Created WeatherForecasts: {createCounts["creatingWeatherForecasts"]}.
            Created ForecastDays: {createCounts["creatingForecastDays"]}.";
        }
        else
        {
            RequestInfo.Status = Statuses.Error;
            RequestInfo.Description += "Error: API response is null. ";
        }

        return ret;
    }
}
