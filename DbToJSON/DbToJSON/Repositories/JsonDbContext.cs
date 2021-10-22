using Microsoft.EntityFrameworkCore;
using DbToJSON.Shared;

namespace DbToJSON.Repositories
{
    public class JsonDbContext : DbContext
    {
        public DbSet<ClientRepaperingInfo> ClientRepaperingInfo { get; set; }


        public JsonDbContext(DbContextOptions<JsonDbContext> options) : base(options)
        {
        }

        public JsonDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-9AB4882; Database=DbToJSON; trusted_connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientRepaperingInfo>(entity => entity.HasKey(e => e.ID));
        }
    }
}
