using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruct;

public class ChargesMap : IEntityTypeConfiguration<Charges>
{
    public void Configure(EntityTypeBuilder<Charges> builder)
    {
        builder.ToTable("chargeses");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.StartDate)
            .HasColumnName("start_date");

        builder.Property(c => c.EndDate)
            .HasColumnName("end_date");

        builder.Property(c => c.ChargeEnergyAdded) 
            .HasColumnName("charge_energy_added").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.StartIdealRangeKm) 
            .HasColumnName("start_ideal_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.EndIdealRangeKm) 
            .HasColumnName("end_ideal_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.StartBatteryLevel)
            .HasColumnName("start_battery_level");

        builder.Property(c => c.EndBatteryLevel)
            .HasColumnName("end_battery_level");

        builder.Property(c => c.DurationMin)
            .HasColumnName("duration_min");

        builder.Property(c => c.OutsideTempAvg) 
            .HasColumnName("outside_temp_avg").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.StartRatedRangeKm) 
            .HasColumnName("start_rated_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.EndRatedRangeKm) 
            .HasColumnName("end_rated_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.ChargeEnergyUsed) 
            .HasColumnName("charge_energy_used").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.Cost) 
            .HasColumnName("cost").HasColumnType("decimal(8, 6)");
 
    }
}