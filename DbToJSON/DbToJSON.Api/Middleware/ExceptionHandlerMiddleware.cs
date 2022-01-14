namespace DbToJSON.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate? _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
            }
            catch (Exception ex)
            { 
            }
        }
    }
}
