// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using TeslaApi.Contract;

var env = Environment.GetCommandLineArgs();
var userkey = "-user=";
var passkey = "-pwd=";
var user = "";
var pass = "";
foreach (var item in env)
{
    if (item.StartsWith(userkey))
    {
        user = item.Replace(userkey, "");
    }
    if (item.StartsWith(passkey))
    {
        pass = item.Replace(passkey, "");
    }
}

if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
{
    return;
}

var (verifier, challenge) = Pkce.PkceChallenge(86);
var state = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");

var cookieContainer = new CookieContainer();
using var handler = new HttpClientHandler()
{
    CookieContainer = cookieContainer,
    AllowAutoRedirect = true
};
var httpClient = new HttpClient(handler);

httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36");
httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
httpClient.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");

// var url = $"https://auth.tesla.com/oauth2/v3/authorize?client_id=ownerapi&code_challenge={challenge}&code_challenge_method=S256&redirect_uri=https%3A%2F%2Fauth.tesla.com%2Fvoid%2Fcallback&response_type=code&scope=openid+email+offline_access&state={state}";
var url = $"https://auth.tesla.com/oauth2/v3/authorize?client_id=ownerapi&code_challenge={challenge}&code_challenge_method=S256&redirect_uri=https://auth.tesla.com/void/callback&response_type=code&scope=openid email offline_access&state={state}&login_hint={user}";
var url2 = $"https://auth.tesla.cn/zh_cn/oauth2/v3/authorize?client_id=ownerapi&skip_redirection=true&locale=zh-CN&code_challenge={challenge}&code_challenge_method=S256&redirect_uri=https://auth.tesla.com/void/callback&response_type=code&scope=openid email offline_access&state={state}&login_hint={user}";
Console.WriteLine(url2);
var respMsg = await httpClient.GetAsync(url2);

IEnumerable<string>? heads;
if (!respMsg.Headers.TryGetValues("Set-Cookie", out heads) || heads == null || !heads.Any())
{
    Console.WriteLine("no heades");
    return;
}

var html = await respMsg.Content.ReadAsStringAsync();
Console.WriteLine(html);
string pattern = @"<input type=""hidden"" name=""([^""]+)"" value=""([^""]+)"" />";
MatchCollection matches = Regex.Matches(html, pattern);
Dictionary<string, string> formData = [];
foreach (Match match in matches)
{
    string name = match.Groups[1].Value;
    string value = match.Groups[2].Value;
    if (!formData.TryAdd(name, value))
    {
        formData[name] = value;
    }
}

formData.TryAdd("identity", user);
formData.TryAdd("credential", pass);

var formContent = new FormUrlEncodedContent(formData);
try
{
    httpClient.DefaultRequestHeaders.Add("origin", "https://auth.tesla.cn");
    httpClient.DefaultRequestHeaders.Add("referer", url2);
    
    var response = await httpClient.PostAsync(url2, formContent);

    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);
    Console.WriteLine($"Request failed with status code {response.StatusCode}");

    Uri location = response.Headers.Location;
    Console.WriteLine($"location: {location}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}