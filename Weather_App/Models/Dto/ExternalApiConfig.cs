namespace Weather_App.Models.Dto
{
    public class ExternalApiConfig
    {
        public string Key { get; set; }

        public Uri Url { get; set; }

        public string Address { get; set; }

        public Dictionary<string, string> EndPoints { get; set; }
    }
}
