using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbToJSON.BusinessDomain.Common;

namespace DbToJSON.BusinessDomain.Entities
{
    public class Category 
    {
        public Guid CategoryId { get; set; }
        public string? Name { get; set; }    
        public ICollection<Event>? Events { get; set; }
        //todo: to resolve the above accessiblity issue
    }
}
