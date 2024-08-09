namespace Weather_App.Exceptions
{
    public class ExternalApiConnectionException : Exception
    {
        public ExternalApiConnectionException()
            : base("External api connection error.")
        {
        }

        public ExternalApiConnectionException(string message)
            : base(message)
        {
        }

        public ExternalApiConnectionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
