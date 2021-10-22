using System;
using System.ComponentModel.DataAnnotations;

namespace DbToJSON.Shared
{
    public class ClientRepaperingInfo
    {
        public long ID { get; set; }
        public string PackageId { get; set; }
        public string ClientId { get; set; }
        public string PackageInstanceId { get; set; }
        public string Comments { get; set; }
        public string JSON { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
