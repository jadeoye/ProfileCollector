namespace ProfileCollector.Server.Utilities
{
    public class Envelope<T>
    {
        public T Result { get; }
        public string ErrorMessage { get; }
        public DateTime TimeGenerated { get; }


        protected internal Envelope(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }
    }
}
