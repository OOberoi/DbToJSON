using Microsoft.EntityFrameworkCore;
using DbToJSON.Shared;

namespace DbToJSON.Repositories
{
    public class JsonDbContext : DbContext
    {
        public DbSet<RepaperingInfo> RepaperingInfo { get; set; }

        public JsonDbContext(DbContextOptions<JsonDbContext> options) : base(options)
        {

        }
    }
}
