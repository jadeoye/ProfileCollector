namespace ProfileCollector.Server.Utilities
{
    public sealed class Envelope : Envelope<string>
    {
        private Envelope(string errorMessage)
            : base(null, errorMessage)
        {
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Ok()
        {
            return new Envelope(null);
        }

        public static Envelope Accepted()
        {
            return new Envelope(null);
        }

        public static Envelope<T> Accepted<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Created()
        {
            return new Envelope(null);
        }

        public static Envelope<T> Created<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }
    }
}
