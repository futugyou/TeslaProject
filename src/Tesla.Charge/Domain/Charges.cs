namespace Domain;

public class Charges
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal ChargeEnergyAdded { get; set; }
    public decimal StartIdealRangeKm { get; set; }
    public decimal EndIdealRangeKm { get; set; }
    public int StartBatteryLevel { get; set; }
    public int EndBatteryLevel { get; set; }
    public int DurationMin { get; set; }
    public decimal OutsideTempAvg { get; set; }
    public int VehicleId { get; set; }
    public int AddressId { get; set; }
    public int PositionId { get; set; }
    public int GeofenceId { get; set; }
    public decimal StartRatedRangeKm { get; set; }
    public decimal EndRatedRangeKm { get; set; }
    public decimal ChargeEnergyUsed { get; set; }
    public decimal Cost { get; set; }
    public List<ChargesDetail> ChargesDetails { get; set; }
}
