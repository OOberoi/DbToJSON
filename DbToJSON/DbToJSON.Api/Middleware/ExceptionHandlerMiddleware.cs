using DbToJSON.Application.Exceptions;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DbToJSON.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            { 
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception ex)
        {
             
            throw new NotImplementedException();
        }
    }
}
