using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DbToJSON.Api.Utility
{
    public class FileResultContentTypeOperationFilter
    {
        public void Apply(OpenApiOperation op, OperationFilterContext ctx)
        { 
            var reqAttr = ctx.MethodInfo.GetCustomAttributes(typeof(FileResultContentTypeAttribute), false)
                .Cast<FileResultContentTypeAttribute>() 
                .FirstOrDefault();
            if (reqAttr != null)
            { 
                
            }
            return;
        }
    }
}
