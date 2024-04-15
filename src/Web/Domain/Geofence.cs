namespace Domain;

public class Geofence
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public decimal Radius { get; set; } 
    public decimal CostPerUnit { get; set; } 
    public DateTime InsertedAt { get; set; }
    public DateTime UpdatedAt { get; set; } 
}

public interface IGeofenceRepository : IRepository<Geofence> { }