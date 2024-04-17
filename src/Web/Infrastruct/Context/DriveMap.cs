using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruct;

public class DriveMap : IEntityTypeConfiguration<Drive>
{
    public void Configure(EntityTypeBuilder<Drive> builder)
    {
        builder.ToTable("drivees");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id"); 

        builder.HasOne(e => e.StartAddressId);
        builder.HasOne(e => e.EndAddressId);
        builder.HasOne(e => e.StartGeofenceId);
        builder.HasOne(e => e.EndGeofenceId);
        builder.HasOne(e => e.StartPositionId);
        builder.HasOne(e => e.EndPositionId);

        builder.Property(c => c.OutsideTempAvg)
            .HasColumnName("outside_temp_avg").HasColumnType("decimal(8, 6)");
        builder.Property(c => c.SpeedMax)
            .HasColumnName("speed_max").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.StartDate)
            .HasColumnName("start_date") ; 
        builder.Property(c => c.EndDate)
            .HasColumnName("end_date") ; 

        builder.Property(c => c.PowerMax)
            .HasColumnName("power_max").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.PowerMin)
            .HasColumnName("power_min").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.StartIdealRangeKm)
            .HasColumnName("start_ideal_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.EndIdealRangeKm)
            .HasColumnName("end_ideal_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.StartKm)
            .HasColumnName("start_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.EndKm)
            .HasColumnName("end_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.Distance)
            .HasColumnName("distance").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.DurationMin)
            .HasColumnName("duration_min").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.InsideTempAvg)
            .HasColumnName("inside_temp_avg").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.StartRatedRangeKm)
            .HasColumnName("start_rated_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.EndRatedRangeKm)
            .HasColumnName("end_rated_range_km").HasColumnType("decimal(8, 6)"); 
    }
}