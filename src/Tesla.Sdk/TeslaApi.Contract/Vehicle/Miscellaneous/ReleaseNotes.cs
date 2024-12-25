
namespace TeslaApi.Contract.Vehicle.Miscellaneous;

public class ReleaseNotesRequest
{
    [JsonPropertyName("staged")]
    public bool Staged { get; set; }
}
public class ReleaseNotesResponse : ResponseBase
{
    [JsonPropertyName("response")]
    public Response Response { get; set; }
}

public class ReleaseNote
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("subtitle")]
    public string Subtitle { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("customer_version")]
    public string CustomerVersion { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }
}

public class Response
{
    [JsonPropertyName("release_notes")]
    public List<ReleaseNote> ReleaseNotes { get; set; }

    [JsonPropertyName("deployed_version")]
    public string DeployedVersion { get; set; }

    [JsonPropertyName("staged_version")]
    public object StagedVersion { get; set; }
}