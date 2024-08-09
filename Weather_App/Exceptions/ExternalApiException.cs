namespace Weather_App.Exceptions
{
    public class ExternalApiException : Exception
    {
        public ExternalApiException()
            : base("External api encountered a problem.")
        {
        }

        public ExternalApiException(string message)
            : base(message)
        {
        }

        public ExternalApiException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
