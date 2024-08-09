using Newtonsoft.Json;
using Weather_App.Data.Converters;

namespace Weather_App.Models.Shared
{
    public class ExternalApiRootObject<TEntity>
    {
        public string Get { get; set; }
        [JsonConverter(typeof(ToDictionaryStringStringJsonConverter))]
        public Dictionary<string, string> Parameters { get; set; }
        [JsonConverter(typeof(ToDictionaryStringStringJsonConverter))]
        public Dictionary<string, string>? Errors { get; set; }
        public int Results { get; set; }
        public Dictionary<string, int>? Paging { get; set; }
        public IEnumerable<TEntity> Response { get; set; }
    }
}
