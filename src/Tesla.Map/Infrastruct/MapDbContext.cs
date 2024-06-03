using Domain;
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

    public DbSet<Address> Addresses { get; set; } 
    public DbSet<Geofence> Geofences { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new AddressMap()); 
        _ = modelBuilder.ApplyConfiguration(new GeofenceMap()); 

        base.OnModelCreating(modelBuilder);
    }
}