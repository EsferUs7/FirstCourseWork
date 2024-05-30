namespace MethodsLibrary
{
    public class ValueTooSmallException : Exception
    {
        public ValueTooSmallException() { }

        public ValueTooSmallException(string message) : base(message) { }
    }
}
