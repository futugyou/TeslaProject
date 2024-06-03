using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruct;

public class GeofenceMap : IEntityTypeConfiguration<Geofence>
{
    public void Configure(EntityTypeBuilder<Geofence> builder)
    {
        builder.ToTable("geofences");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id"); 
 

        builder.Property(c => c.InsertedAt)
            .HasColumnName("inserted_at") ; 
        builder.Property(c => c.UpdatedAt)
            .HasColumnName("updated_at") ; 

        builder.Property(c => c.Latitude)
            .HasColumnName("latitude").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.Longitude)
            .HasColumnName("longitude").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.Radius)
            .HasColumnName("radius").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.CostPerUnit)
            .HasColumnName("Cost_per_unit").HasColumnType("decimal(8, 6)");
 
    }
}