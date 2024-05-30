namespace MethodsLibrary
{
    public class ValueTooHugeException : Exception
    {
        public ValueTooHugeException() { }

        public ValueTooHugeException(string message) : base(message) { }
    }
}
