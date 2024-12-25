namespace TeslaApi.Contract;

public class ResponseBase
{
    [JsonPropertyName("error")]
    public string error { get; set; } = "";
    [JsonPropertyName("error_description")]
    public string error_description { get; set; } = "";
    [JsonPropertyName("error_uri")]
    public string error_uri { get; set; } = "";
}

public class ResponseBase<T> where T : class
{
    [JsonPropertyName("error")]
    public string error { get; set; } = "";
    [JsonPropertyName("error_description")]
    public string error_description { get; set; } = "";
    [JsonPropertyName("error_uri")]
    public string error_uri { get; set; } = "";
    [JsonPropertyName("response")]
    public T Response { get; set; } 
}
