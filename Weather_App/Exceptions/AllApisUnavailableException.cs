namespace Weather_App.Exceptions
{
    public class AllApisUnavailableException : Exception
    {
        public AllApisUnavailableException()
            : base("All external APIs are currently unavailable.")
        {
        }

        public AllApisUnavailableException(string message)
            : base(message)
        {
        }

        public AllApisUnavailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
