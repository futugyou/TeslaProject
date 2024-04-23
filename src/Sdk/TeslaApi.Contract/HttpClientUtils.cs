using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeslaApi.Contract;

namespace TeslaApi;

public static class HttpClientUtils
{
    class NullClass
    {

    }
    public static async Task<Response> UtilsPostAsync<Response>(this HttpClient httpClient, string path)
    {
        return await httpClient.UtilsPostAsync<NullClass, Response>(null, path, "");
    }
    public static async Task<Response> UtilsPostAsync<Request, Response>(this HttpClient httpClient, Request request, string path)
    {
        return await httpClient.UtilsPostAsync<Request, Response>(request, path, "");
    }
    public static async Task<Response> UtilsPostAsync<Response>(this HttpClient httpClient, string path, string token)
    {
        return await httpClient.UtilsPostAsync<NullClass, Response>(null, path, token);
    }
    public static async Task<Response> UtilsPostAsync<Request, Response>(this HttpClient httpClient, Request? request, string path, string token)
    {
        HttpContent? content = default;
        if (request != null)
        {
            var json = JsonSerializer.Serialize(request, JsonSerializerExtensions.CreateJsonSetting());
            content = new StringContent(json, Encoding.UTF8, TeslaApiConst.MEDIA_TYPE);
        }

        if (!string.IsNullOrEmpty(token))
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TeslaApiConst.TESLA_Authorization_Type, token);
        }

        var responseMessage = await httpClient.PostAsync(path, content);
        var result = await responseMessage.Content.ReadAsStringAsync();
        if (responseMessage.IsSuccessStatusCode)
        {
            return JsonSerializer.Deserialize<Response>(result, JsonSerializerExtensions.CreateJsonSetting()) ?? throw new HttpRequestException(result);
        }
        else
        {
            string errorMessage = $"Request failed with status code {responseMessage.StatusCode}: {responseMessage.ReasonPhrase}. Response content: {result}";
            throw new HttpRequestException(errorMessage, null, responseMessage.StatusCode);
        }
    }

    public static async Task<Response> UtilsGetAsync<Response>(this HttpClient httpClient, string path)
    {
        return await UtilsGetAsync<Response>(httpClient, path, "");
    }

    public static async Task<Response> UtilsGetAsync<Response>(this HttpClient httpClient, string path, string token)
    {
        if (!string.IsNullOrEmpty(token))
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TeslaApiConst.TESLA_Authorization_Type, token);
        }
        var responseMessage = await httpClient.GetAsync(path);
        var result = await responseMessage.Content.ReadAsStringAsync();
        if (responseMessage.IsSuccessStatusCode)
        {
            return JsonSerializer.Deserialize<Response>(result, JsonSerializerExtensions.CreateJsonSetting()) ?? throw new HttpRequestException(result);
        }
        else
        {
            string errorMessage = $"Request failed with status code {responseMessage.StatusCode}: {responseMessage.ReasonPhrase}. Response content: {result}";
            throw new HttpRequestException(errorMessage, null, responseMessage.StatusCode);
        }
    }
}
