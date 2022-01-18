using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DbToJSON.Api.Utility
{
    public class FileResultContentTypeOperationFilter
    {
        public void Apply(OpenApiOperation oper, OperationFilterContext ctx)
        { 
            var reqAttr = ctx.MethodInfo.GetCustomAttributes(typeof(FileResultContentTypeAttribute), false)
                .Cast<FileResultContentTypeAttribute>() 
                .FirstOrDefault();
            if (reqAttr != null)
            { 
                oper.Responses.Clear(); 
            }
            return;
        }
    }
}
