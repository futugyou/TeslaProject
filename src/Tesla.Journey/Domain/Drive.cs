namespace Domain;

public class Drive
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal OutsideTempAvg { get; set; }
    public decimal SpeedMax { get; set; }
    public decimal PowerMax { get; set; }
    public decimal PowerMin { get; set; }
    public decimal StartIdealRangeKm { get; set; }
    public decimal EndIdealRangeKm { get; set; }
    public decimal StartKm { get; set; }
    public decimal EndKm { get; set; }
    public decimal Distance { get; set; }
    public decimal DurationMin { get; set; }
    public int VehicleId { get; set; }
    public decimal InsideTempAvg { get; set; }
    public int StartAddressId { get; set; }
    public int EndAddressId { get; set; }
    public decimal StartRatedRangeKm { get; set; }
    public decimal EndRatedRangeKm { get; set; }
    public int StartGeofenceId { get; set; }
    public int EndGeofenceId { get; set; }
    public Position StartPositionId { get; set; }
    public Position EndPositionId { get; set; }
}
