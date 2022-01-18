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
                oper.Responses.Add("200", new OpenApiResponse
                {
                    Content = new Dictionary<string, OpenApiMediaType>()
                    {
                        {
#pragma warning disable CS8604 // Possible null reference argument.
                            reqAttr.ContentType, new OpenApiMediaType
#pragma warning restore CS8604 // Possible null reference argument.
                            {
                                Schema = new OpenApiSchema
                                {
                                    Type = "string",
                                    Format = "binary"
                                }
                            }
                        }
                    }
                });
            }          
        }
    }
}
