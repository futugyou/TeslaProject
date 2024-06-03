using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastruct;
public class JourneyDbContext : DbContext
{
    public JourneyDbContext(DbContextOptions<JourneyDbContext> options) : base(options)
    {
    }

    protected JourneyDbContext()
    {
    }

    public DbSet<Drive> Drives { get; set; } 

    public DbSet<Position> Positions { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new DriveMap()); 
        _ = modelBuilder.ApplyConfiguration(new PositionMap()); 

        base.OnModelCreating(modelBuilder);
    }
}