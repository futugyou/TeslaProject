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
    public Vehicle VehicleId { get; set; }
    public decimal InsideTempAvg { get; set; }
    public Address StartAddressId { get; set; }
    public Address EndAddressId { get; set; }
    public decimal StartRatedRangeKm { get; set; }
    public decimal EndRatedRangeKm { get; set; } 
    public Geofence StartGeofenceId { get; set; } 
    public Geofence EndGeofenceId { get; set; } 
}
public interface IDriveRepository : IRepository<Drive> { }