using DomainObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainObjects
{
    public class TiContext : DbContext
    {
        public TiContext(DbContextOptions<TiContext> options) : base(options)
        {
            //dotnet ef migrations add init --project DomainObjects --context TiContext --startup-project Api
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyUtcDateTimeConverter();
        }

        public DbSet<Draft> Drafts { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Race> Races { get; set; }
    }
}
