using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruct;

public class UserContext : DbContext
{
    public DbSet<Token> Tokens { get; set; } 

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

        base.OnModelCreating(modelBuilder);
    } 
}