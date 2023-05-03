namespace FluxoCaixa.Api.Errors
{
    public class CustomException : Exception
    {
        public CustomException(object? value = null)
        {
            Value = value;
            StatusCode = 500;
        }

        public int StatusCode { get; }

        public object? Value { get; }
    }
}