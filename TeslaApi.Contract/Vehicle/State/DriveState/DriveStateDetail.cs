using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.DriveState
{
    public class DriveStateDetail
    {
        [JsonPropertyName("corrected_latitude")]
        public float CorrectedLatitude { get; set; }
        [JsonPropertyName("corrected_longitude")]
        public float CorrectedLongitude { get; set; }
        [JsonPropertyName("gps_as_of")]
        public int? GpsAsOf { get; set; }
        [JsonPropertyName("heading")]
        public int? Heading { get; set; }
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }
        [JsonPropertyName("native_latitude")]
        public float NativeLatitude { get; set; }
        [JsonPropertyName("native_location_supported")]
        public int? NativeLocationSupported { get; set; }
        [JsonPropertyName("native_longitude")]
        public float NativeLongitude { get; set; }
        [JsonPropertyName("native_type")]
        public string NativeType { get; set; }
        [JsonPropertyName("power")]
        public int? Power { get; set; }
        [JsonPropertyName("shift_state")]
        public object ShiftState { get; set; }
        [JsonPropertyName("speed")]
        public object Speed { get; set; }
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
    }

}