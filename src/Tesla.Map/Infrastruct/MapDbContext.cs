using Microsoft.EntityFrameworkCore;

namespace Infrastruct;
public class MapDbContext : DbContext
{
    public MapDbContext(DbContextOptions<MapDbContext> options) : base(options)
    {
    }

    protected MapDbContext()
    {
    }

    public DbSet<AddressMap> AddressMaps { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new AddressMap()); 

        base.OnModelCreating(modelBuilder);
    }
}