using System.Text.Json.Serialization;

namespace TeslaApi.Contract.User;

public class MeReponse : ResponseBase<MeReponseDetail>
{ 
}

public class MeReponseDetail
{
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("full_name")]
    public string FullName { get; set; }
    [JsonPropertyName("profile_image_url")]
    public string ProfileImageUrl { get; set; }
}
