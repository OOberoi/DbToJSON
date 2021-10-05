using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DbToJSON.Repositories;
using Microsoft.Extensions.Configuration;

namespace DbToJSON
{
    
    public class Startup 
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    }
}
