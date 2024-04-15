using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruct;

public class UserContext : DbContext
{
  public DbSet<Token> Tokens { get; set; }
  public DbSet<Weixin> Weixins { get; set; }
  public DbSet<Address> Addresses { get; set; }
  public DbSet<Vehicle> Vehicles { get; set; }
  public DbSet<Charges> Chargeses { get; set; }
  public DbSet<ChargesDetail> ChargesDetails { get; set; }

  protected UserContext()
  {
  }

  public UserContext(DbContextOptions<UserContext> options)
    : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    _ = modelBuilder.ApplyConfiguration(new TokenMap());
    _ = modelBuilder.ApplyConfiguration(new WeixinMap());
    _ = modelBuilder.ApplyConfiguration(new AddressMap());
    _ = modelBuilder.ApplyConfiguration(new VehicleMap());
    _ = modelBuilder.ApplyConfiguration(new ChargesMap());
    _ = modelBuilder.ApplyConfiguration(new ChargesDetailMap());

    base.OnModelCreating(modelBuilder);
  }
}