﻿using Weather_App.Exceptions;
using Weather_App.Models.Dto;
using Weather_App.Data.Repositories.Base;
using Weather_App.Data.Repositories.Custom;
using Weather_App.Models.Entities.Management;
using Weather_App.Models.Entities.Shared.EntityBase;
using Weather_App.Models.Shared;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Weather_App.Data.Services.ExternalApisService;

public abstract class ExternalApiSyncService<TPrimaryKey, TEntityBase, TEndPointEntity>
    where TEntityBase : class, IEntityBase<TPrimaryKey>, new()
{
    public static readonly string UpdatingMap = "UPDATE";

    private int ReconnectionAttempts = 5;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;
    protected readonly ICustomRepository CustomRepository;
    protected readonly IEntityBaseRepository<TPrimaryKey, TEntityBase> EntityBaseRepository;

    private KeyValuePair<string, ExternalApiConfig>? ExternalApiConfig { get; set; }
    protected SyncRequestInfo RequestInfo { get; set; } = new SyncRequestInfo();


    protected ExternalApiSyncService(
        ICustomRepository customRepository,
        IConfiguration configuration,
        IHttpClientFactory httpClientFactory,
        IEntityBaseRepository<TPrimaryKey, TEntityBase> entityBaseRepository
        ) 
    {
        CustomRepository = customRepository;
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
        EntityBaseRepository = entityBaseRepository;    
    }


    protected async Task<(IEnumerable<TEntityBase> Results, int Pages)> BeginRequest<TApiResult>(string parameters,
        Func<ExternalApiRootObject<TApiResult>, Task<IEnumerable<TEntityBase>>>? additionalOperation = null)
        where TApiResult : class, new()
    {
        var watch = Stopwatch.StartNew();
        var endPointEntityName = typeof(TEndPointEntity).Name;
        RequestInfo.BaseEntity = endPointEntityName;

        ExternalApiConfig ??= new KeyValuePair<string, ExternalApiConfig>("RapidAPI", _configuration.GetSection("ExternalApis:RapidAPI").Get<ExternalApiConfig>());

        try
        {
            var apiName = ExternalApiConfig!.Value.Key;
            var endPointName = ExternalApiConfig.Value.Value.EndPoints[endPointEntityName];

            RequestInfo.ApiName = apiName;
            RequestInfo.EndPoint = endPointName;
            RequestInfo.Parameters = parameters;

            var client = _httpClientFactory.CreateClient(apiName);
            var response = await client.GetAsync(endPointName + parameters);
            var readedString = await response.Content.ReadAsStringAsync();

            var result = CatchErrors(JsonConvert.DeserializeObject<ExternalApiRootObject<TApiResult>>(readedString));

            var pages = int.Parse(result.Paging["total"].ToString());

            IEnumerable<TEntityBase> entities;
            if (additionalOperation != null)
                entities = await additionalOperation(result);
            else if (endPointEntityName == typeof(TApiResult).Name)
                entities = (IEnumerable<TEntityBase>)  result.Response;
            else
                throw new InvalidOperationException($"Unsupported api entity convertion: '{nameof(TEntityBase)} -> {typeof(TEntityBase)} -> {endPointEntityName} | {nameof(TApiResult)} -> {typeof(TApiResult)}'.");

            var ret = await EntityBaseRepository.CreateOrUpdateMultiAsync(entities);
            var count = ret.Count();

            RequestInfo.BaseAddress = client.BaseAddress?.ToString();
            RequestInfo.GlobalCount = count;

            watch.Stop();
            RequestInfo.ExecutionTime = watch.ElapsedMilliseconds;

            return (ret, pages);
        }
        catch (Exception ex)
        {
            watch.Stop();
            RequestInfo.ExecutionTime = watch.ElapsedMilliseconds;
            throw;
        }
    }

    protected void MapValuesFromExternalApi(object existingEntity, object apiObject, string mapType)
    {
        var apiType = apiObject.GetType();
        var existingEntityType = existingEntity.GetType();
        var entityName = existingEntityType.Name;
        var existingEntityProperties = existingEntityType.GetProperties().ToList();

        var existingEntityIdProp = existingEntityProperties.Single(p => p.Name == "Id");
        var id = existingEntityIdProp.GetValue(existingEntity);

        var updateMsgPart = mapType == UpdatingMap ? $"with Id {id}" : "";
        RequestInfo.ProcessingDetails += $@"
        ==== API START {mapType}: {entityName} {updateMsgPart}";

        foreach (var apiProp in apiType.GetProperties())
        {
            var existingEntProp = existingEntityProperties.SingleOrDefault(item => item.Name == apiProp.Name);
            if (existingEntProp != null)
            {
                var newVal = apiProp.GetValue(apiObject);
                var oldVal = existingEntProp.GetValue(existingEntity);

                var isSameValue = Equals(oldVal, newVal);

                if (existingEntProp.Name != existingEntityIdProp.Name && !isSameValue)
                {
                    existingEntProp.SetValue(existingEntity, newVal);

                    RequestInfo.ProcessingDetails += $@"
                    {existingEntProp.Name}: {oldVal} -> {newVal}";
                }
            }
        }

        RequestInfo.ProcessingDetails += $@"
        ==== API END {mapType}: {entityName} {updateMsgPart}";
    }

    private ExternalApiRootObject<TApiResult> CatchErrors<TApiResult>(ExternalApiRootObject<TApiResult> result)
        where TApiResult : class, new()
    {
        var errors = result.Errors;
        if (errors?.Count > 0)
        {
            if (errors.ContainsKey("rateLimit"))
                throw new ExternalApiConnectionException(JsonConvert.SerializeObject(errors));
            else if (errors.ContainsKey("requests"))
                throw new ExternalApiConnectionException(JsonConvert.SerializeObject(errors));
            else
                throw new ExternalApiException(JsonConvert.SerializeObject(errors));
        }

        return result;
    }

    protected async Task SaveRequestInformation()
    {
        RequestInfo.When = DateTime.UtcNow;
        await CustomRepository.CreateAsync<long, SyncRequestInfo>(RequestInfo);
        RequestInfo = new SyncRequestInfo();
    }
}
