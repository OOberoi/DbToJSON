using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbToJSON.BusinessDomain.Entities
{
    internal class Event
    {
        public Guid EventId { get; set; }
        public string? EventName { get; set; }
        public double? Price  { get; set; }
        public string? Artist { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string Url { get; set; }
        public Guid CategoryId { get; set; }
    }
}
