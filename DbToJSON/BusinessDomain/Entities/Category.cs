using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbToJSON.BusinessDomain.Common;

namespace DbToJSON.BusinessDomain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }    
        public ICollection<Event>? Events { get; set; }
    }
}
