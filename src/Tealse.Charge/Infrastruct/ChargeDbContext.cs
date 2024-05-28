using Domain;
using Microsoft.EntityFrameworkCore;

namespace Tealse.Charge.Infrastruct;
public class ChargeDbContext : DbContext
{
    public ChargeDbContext(DbContextOptions<ChargeDbContext> options) : base(options)
    {
    }

    protected ChargeDbContext()
    {
    }

    public DbSet<Charges> Chargeses { get; set; }
    public DbSet<ChargesDetail> ChargesDetails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new ChargesMap());
        _ = modelBuilder.ApplyConfiguration(new ChargesDetailMap());

        base.OnModelCreating(modelBuilder);
    }
}