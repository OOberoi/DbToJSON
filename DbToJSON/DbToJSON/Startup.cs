using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DbToJSON.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DbToJSON
{
    
    public class Startup 
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigursServices(IServiceCollection services)
        {
            services.AddDbContext<JsonDbContext>(options =>
                options.UseSqlServer("server=DESKTOP-9AB4882; Database=DbToJSON; trusted_connection=true;"));
            services.AddScoped<IRepaperingInfo, RepaperingInfoRepository>();
        }

    }
}
