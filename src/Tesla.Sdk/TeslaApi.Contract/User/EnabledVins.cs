namespace TeslaApi.Contract.User;

public class EnabledVins
{
    [JsonPropertyName("vin")]
    public string Vin { get; set; }
    [JsonPropertyName("next_appt_timestamp")]
    public object NextApptTimestamp { get; set; }
    [JsonPropertyName("next_appt_end_timestamp")]
    public object NextApptEndTimestamp { get; set; }
}
