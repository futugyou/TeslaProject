using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruct;

public class VehicleMap : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicles");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.InsertedAt)
            .HasColumnName("inserted_at");

        builder.Property(c => c.UpdatedAt)
            .HasColumnName("updated_at"); 

        builder.Property(c => c.Eid)
            .HasColumnName("eid"); 

        builder.Property(c => c.Vid)
            .HasColumnName("vid"); 

        builder.Property(c => c.Efficiency)
            .HasColumnName("efficiency"); 

        builder.Property(c => c.DisplayPriority)
            .HasColumnName("display_priority"); 

        builder.Property(c => c.Model)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("model"); 

        builder.Property(c => c.Vin)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("vin"); 

        builder.Property(c => c.Name)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("name"); 

        builder.Property(c => c.TrimBadging)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("trim_badging"); 

        builder.Property(c => c.ExteriorColor)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("exterior_color"); 

        builder.Property(c => c.SpoilerType)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("spoiler_type"); 

        builder.Property(c => c.WheelType)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("wheel_type"); 

        builder.Property(c => c.MarketingName)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("marketing_name"); 

    }
}