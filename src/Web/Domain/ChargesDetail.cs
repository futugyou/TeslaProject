namespace Domain;

public class ChargesDetail
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool BatteryHeaterOn { get; set; }
    public int BatteryLevel { get; set; }
    public decimal ChargeEnergyAdded { get; set; }
    public int ChargerActualCurrent { get; set; }
    public int ChargerPhases { get; set; }
    public int ChargerPilotCurrent { get; set; }
    public int ChargerPower { get; set; }
    public int ChargerVoltage { get; set; }
    public bool FastChargerPresent { get; set; }
    public string ConnChargeCable { get; set; }
    public string FastChargerBrand { get; set; }
    public string FastChargerType { get; set; }
    public decimal IdealBatteryRange { get; set; }
    public bool NotEnoughPowerToHeat { get; set; }
    public decimal OutsideTemp { get; set; } 
    public bool BatteryHeater { get; set; }
    public bool BatteryHeaterNoPower { get; set; }
    public decimal RatedBatteryRangeKm { get; set; }
    public int UsableBatteryLevel { get; set; }
    public Charges Charges { get; set; }
}

public interface IChargesDetailRepository : IRepository<ChargesDetail> { }