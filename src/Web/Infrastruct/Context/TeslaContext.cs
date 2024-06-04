using Domain;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Infrastruct;

public class TeslaContext : DbContext
{
  public DbSet<Token> Tokens { get; set; }
  public DbSet<Weixin> Weixins { get; set; }
  public DbSet<Address> Addresses { get; set; }
  public DbSet<Vehicle> Vehicles { get; set; }
  public DbSet<Charges> Chargeses { get; set; }
  public DbSet<ChargesDetail> ChargesDetails { get; set; }
  public DbSet<Drive> Drives { get; set; }
  public DbSet<Geofence> Geofences { get; set; }
  public DbSet<Position> Positions { get; set; }

  protected TeslaContext()
  {
  }

  public TeslaContext(DbContextOptions<TeslaContext> options)
    : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    _ = modelBuilder.ApplyConfiguration(new TokenMap());
    _ = modelBuilder.ApplyConfiguration(new WeixinMap());
    _ = modelBuilder.ApplyConfiguration(new AddressMap());
    _ = modelBuilder.ApplyConfiguration(new VehicleMap());
    _ = modelBuilder.ApplyConfiguration(new ChargesMap());
    _ = modelBuilder.ApplyConfiguration(new ChargesDetailMap());
    _ = modelBuilder.ApplyConfiguration(new DriveMap());
    _ = modelBuilder.ApplyConfiguration(new GeofenceMap());
    _ = modelBuilder.ApplyConfiguration(new PositionMap());

    modelBuilder.AddTransactionalOutboxEntities();
  }
}