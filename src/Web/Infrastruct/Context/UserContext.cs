using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruct;

public class UserContext : DbContext
{
  public DbSet<Token> Tokens { get; set; }
  public DbSet<Weixin> Weixins { get; set; }

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

    base.OnModelCreating(modelBuilder);
  }
}