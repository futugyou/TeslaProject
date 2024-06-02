using System.Text.Json.Serialization;


namespace TeslaApi.Contract.Vehicle.Vehicles;

public class VehicleDetail
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("vehicle_id")]
    public long VehicleId { get; set; }
    [JsonPropertyName("vin")]
    public string Vin { get; set; }
    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; }
    [JsonPropertyName("option_codes")]
    public string OptionCodes { get; set; }
    [JsonPropertyName("color")]
    public object Color { get; set; }
    [JsonPropertyName("tokens")]
    public string[] Tokens { get; set; }
    [JsonPropertyName("state")]
    public string State { get; set; }
    [JsonPropertyName("in_service")]
    public bool InService { get; set; }
    [JsonPropertyName("id_s")]
    public string IdS { get; set; }
    [JsonPropertyName("calendar_enabled")]
    public bool CalendarEnabled { get; set; }
    [JsonPropertyName("api_version")]
    public int? ApiVersion { get; set; }
    [JsonPropertyName("backseat_token")]
    public object BackseatToken { get; set; }
    [JsonPropertyName("backseat_token_updated_at")]
    public DateTime? BackseatTokenUpdatedAt { get; set; }
}