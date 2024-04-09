using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class OnboardingExperienceResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public OnboardingExperienceDetail Response { get; set; }
}
public class OnboardingExperienceDetail
{
    [JsonPropertyName("entry_point_text")]
    public string EntryPointText { get; set; }
    [JsonPropertyName("show_postdelivery_on_startup")]
    public bool ShowPostdeliveryOnStartup { get; set; }
    [JsonPropertyName("display_page_on_startup")]
    public object DisplayPageOnStartup { get; set; }
    [JsonPropertyName("show_on_login")]
    public bool ShowOnLogin { get; set; }
    [JsonPropertyName("show_in_menu")]
    public bool ShowInMenu { get; set; }
}
