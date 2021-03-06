using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbToJSON.BusinessDomain.Common;

namespace DbToJSON.BusinessDomain.Entities
{
    public class Order : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal? OrderTotal { get; set; }
        public DateTime? DateOrderPlaced { get; set; }
        public bool? OrderPaid { get; set; }
    }
}
