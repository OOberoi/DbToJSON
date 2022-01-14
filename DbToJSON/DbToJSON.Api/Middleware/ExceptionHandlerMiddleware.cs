namespace DbToJSON.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate? _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    }
}
