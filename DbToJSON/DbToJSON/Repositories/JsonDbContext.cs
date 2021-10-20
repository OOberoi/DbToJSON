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

        public JsonDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RepaperingInfo>(entity => entity.HasKey(e => e.ID));
        }
    }
}
