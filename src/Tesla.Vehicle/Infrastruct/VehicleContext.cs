using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastruct;

public class VehicleContext : DbContext
{
  public DbSet<Vehicle> Vehicles { get; set; }
  protected VehicleContext()
  {
  }

  public VehicleContext(DbContextOptions<VehicleContext> options)
    : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    _ = modelBuilder.ApplyConfiguration(new VehicleMap());

    base.OnModelCreating(modelBuilder);
  }
}