using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Weather_App.Data.Converters
{
    public class ToDictionaryStringStringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                var parsedResults = token.ToObject<IEnumerable<string>>();
                var newObj = new Dictionary<string, string>();

                var count = 0;
                foreach (var item in parsedResults)
                {
                    count++;
                    newObj[count.ToString()] = item;
                }

                return newObj;
            }
            else if (token.Type == JTokenType.Object)
            {
                return token.ToObject<Dictionary<string, string>>();
            }

            return token.ToObject<object>();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
