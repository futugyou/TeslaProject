
namespace TeslaApi.Contract.Vehicle.Commands.Charging;

public class SetScheduledDepartureRequest
{
    [JsonPropertyName("enable")]
    public bool Enable { get; set; }
    [JsonPropertyName("departure_time")]
    public int DepartureTime { get; set; }
    [JsonPropertyName("preconditioning_enabled")]
    public bool PreconditioningEnabled { get; set; }
    [JsonPropertyName("preconditioning_weekdays_only")]
    public bool PreconditioningWeekdaysOnly { get; set; }
    [JsonPropertyName("off_peak_charging_enabled")]
    public bool OffPeakChargingEnabled { get; set; }
    [JsonPropertyName("off_peak_charging_weekdays_only")]
    public bool OffPeakChargingWeekdaysOnly { get; set; }
    [JsonPropertyName("end_off_peak_time")]
    public int EndOffPeakTime { get; set; }
}
