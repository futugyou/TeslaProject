namespace Domain;

public class SocketData
{
    public int Id { get; set; }
    public string UserID { get; set; }
    public long VinID { get; set; }
    public string Vin { get; set; }
    public string Raw { get; set; }
    public bool IsHandled { get; set; }
    public DateTime InsertedAt { get; set; }
}

public interface ISocketDataRepository : IRepository<SocketData> { }