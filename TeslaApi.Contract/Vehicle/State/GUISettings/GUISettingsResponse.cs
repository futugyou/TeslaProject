using System.Text.Json.Serialization;

namespace TeslaApi.Contract.Vehicle.State.GUISettings
{
    public class GUISettingsResponse : ResponseBase
    {
        [JsonPropertyName("response")]
        public GuiSettingsDetail Response { get; set; }
    }
}
