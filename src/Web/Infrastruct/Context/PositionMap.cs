using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastruct;

public class PositionMap : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id");
        builder.HasOne(e => e.VehicleId);
        builder.HasOne(e => e.DriveId);

        builder.Property(c => c.Date) 
            .HasColumnName("date");

        builder.Property(c => c.Latitude)
            .HasColumnName("latitude").HasColumnType("decimal(8, 6)");
        builder.Property(c => c.Longitude)
            .HasColumnName("longitude").HasColumnType("decimal(8, 6)"); 

        builder.Property(c => c.Speed)
            .HasColumnName("speed").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.Power)
            .HasColumnName("power").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.Odometer)
            .HasColumnName("odometer").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.IdealBatteryRangeKm)
            .HasColumnName("ideal_battery_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.BatteryLevel)
            .HasColumnName("battery_level").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.OutsideTemp)
            .HasColumnName("outside_temp").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.Elevation)
            .HasColumnName("elevation").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.FanStatus)
            .HasColumnName("fan_status").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.DriverTempSetting)
            .HasColumnName("driver_temp_setting").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.PassengerTempSetting)
            .HasColumnName("passenger_temp_setting").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.InsideTemp)
            .HasColumnName("inside_temp").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.EstBatteryRangeKm)
            .HasColumnName("est_battery_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.RatedBatteryRangeKm)
            .HasColumnName("rated_battery_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.UsableBatteryLevel)
            .HasColumnName("usable_battery_level").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.TpmsPressureFl)
            .HasColumnName("tpms_pressure_fl").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.TpmsPressureFr)
            .HasColumnName("tpms_pressure_fr").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.TpmsPressureRl)
            .HasColumnName("tpms_pressure_rl").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.TpmsPressureRr)
            .HasColumnName("tpms_pressure_rr").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.IsClimateOn)
            .HasColumnName("is_climate_on");

        builder.Property(c => c.IsRearDefrosterOn)
            .HasColumnName("is_rear_defroster_on");

        builder.Property(c => c.IsFrontDefrosterOn)
            .HasColumnName("is_front_defroster_on");

        builder.Property(c => c.BatteryHeater)
            .HasColumnName("battery_heater");

        builder.Property(c => c.BatteryHeaterOn)
            .HasColumnName("battery_heater_no");

        builder.Property(c => c.BatteryHeaterNoPower)
            .HasColumnName("battery_heater_no_power");
    }
}