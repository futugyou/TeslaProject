
using System.Text.Json.Serialization;
using TeslaApi.Contract.Vehicle.State.VehicleConfig;

namespace TeslaApi.Contract.Vehicle.Products
{
    public class ProductsResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public ProductDetail[] Response { get; set; }
        [JsonPropertyName("count")]
        public int? Count { get; set; }
    }

    public class ProductDetail
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
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
        [JsonPropertyName("access_type")]
        public string AccessType { get; set; }
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
        public object BackseatTokenUpdatedAt { get; set; }
        [JsonPropertyName("vehicle_config")]
        public VehicleConfigDetail VehicleConfig { get; set; }
        [JsonPropertyName("command_signing")]
        public string CommandSigning { get; set; }
    }
}