using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbToJSON.Events.Commands
{
    public class CreateEventCommand
    {
        public int ID { get; set; }
        public Guid myGuid { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
