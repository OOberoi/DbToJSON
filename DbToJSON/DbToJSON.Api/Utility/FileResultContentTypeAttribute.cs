using System;

namespace DbToJSON.Api.Utility
{
    public class FileResultContentTypeAttribute
    {
        public string? ContentType { get; set; }
        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }
    }
}
