namespace Domain;

public class Position
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public decimal Speed { get; set; }
    public decimal Power { get; set; }
    public decimal Odometer { get; set; }
    public decimal IdealBatteryRange { get; set; }
    public decimal BatteryLevel { get; set; }
    public decimal OutsideTemp { get; set; }
    public decimal Elevation { get; set; }
    public decimal FanStatus { get; set; }
    public decimal DriverTempSetting { get; set; }
    public decimal PassengerTempSetting { get; set; }
    public bool IsClimateOn { get; set; }
    public bool IsRearDefrosterOn { get; set; }
    public bool IsFrontDefrosterOn { get; set; }
    public Vehicle VehicleId { get; set; }
    public Drive DriveId { get; set; }
    public decimal InsideTemp { get; set; }
    public bool BatteryHeater { get; set; }
    public bool BatteryHeaterOn { get; set; }
    public bool BatteryHeaterNoPower { get; set; }
    public decimal EstBatteryRange { get; set; }
    public decimal RatedBatteryRangeKm { get; set; }
    public decimal UsableBatteryLevel { get; set; }
    public decimal TpmsPressureFl { get; set; }
    public decimal TpmsPressureFr { get; set; }
    public decimal TpmsPressureRl { get; set; }
    public decimal TpmsPressureRr { get; set; }
}

public interface IPositionRepository : IRepository<Position> { }