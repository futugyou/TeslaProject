namespace Domain;

public class Vehicle
{
         public int Id { get; set; }
        public long Eid { get; set; }
        public long Vid { get; set; }
        public string Model { get; set; }
        public decimal Efficiency { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Vin { get; set; }
        public string Name { get; set; }
        public string TrimBadging { get; set; } 
        public string ExteriorColor { get; set; }
        public string SpoilerType { get; set; }
        public string WheelType { get; set; }
        public int DisplayPriority { get; set; }
        public string MarketingName { get; set; }
}

public interface IVehicleRepository : IRepository<Vehicle> { }