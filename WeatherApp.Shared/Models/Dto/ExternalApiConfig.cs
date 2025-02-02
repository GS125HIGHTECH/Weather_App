namespace WeatherApp.Shared.Models.Dto
{
    public class ExternalApiConfig
    {
        public required string Key { get; set; }

        public required Uri Url { get; set; }

        public required string Address { get; set; }

        public required Dictionary<string, string> EndPoints { get; set; }
    }
}
