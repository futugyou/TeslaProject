using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tesla.Charge.Infrastruct;

public class ChargesDetailMap : IEntityTypeConfiguration<ChargesDetail>
{
    public void Configure(EntityTypeBuilder<ChargesDetail> builder)
    {
        builder.ToTable("charges_detailes");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.Date)
            .HasColumnName("date");

        builder.Property(c => c.BatteryHeaterOn)
            .HasColumnName("battery_heater_on");

        builder.Property(c => c.ChargeEnergyAdded)
            .HasColumnName("charge_energy_added").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.BatteryLevel)
            .HasColumnName("battery_level");

        builder.Property(c => c.ChargerActualCurrent)
            .HasColumnName("charger_actual_current");

        builder.Property(c => c.ChargerPhases)
            .HasColumnName("charger_phases");

        builder.Property(c => c.ChargerPilotCurrent)
            .HasColumnName("charger_pilot_current");

        builder.Property(c => c.ChargerPower)
            .HasColumnName("charger_power");

        builder.Property(c => c.ChargerVoltage)
            .HasColumnName("charger_voltage");

        builder.Property(c => c.FastChargerPresent)
            .HasColumnName("fast_charger_present");

        builder.Property(c => c.ConnChargeCable)
            .HasColumnName("conn_charge_cable")
            .HasColumnType("varchar(200)");

        builder.Property(c => c.FastChargerBrand)
            .HasColumnName("fast_charger_brand")
            .HasColumnType("varchar(200)");

        builder.Property(c => c.FastChargerType)
            .HasColumnName("fast_charger_type")
            .HasColumnType("varchar(200)");

        builder.Property(c => c.IdealBatteryRange)
            .HasColumnName("ideal_battery_range").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.OutsideTemp)
            .HasColumnName("outside_temp").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.NotEnoughPowerToHeat)
            .HasColumnName("not_enough_power_to_heat");

        builder.Property(c => c.BatteryHeater)
            .HasColumnName("battery_heater");

        builder.Property(c => c.BatteryHeaterNoPower)
            .HasColumnName("battery_heater_no_power");

        builder.Property(c => c.RatedBatteryRangeKm)
            .HasColumnName("rated_battery_range_km").HasColumnType("decimal(8, 6)");

        builder.Property(c => c.UsableBatteryLevel)
            .HasColumnName("usable_battery_level");
    }
}