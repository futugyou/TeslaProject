using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Authentication
{
    public class AuthorizeEndPointRequest
    {
        public AuthorizeEndPointRequest(string clientId, string codeChallengeMethod, string redirectUri, string responseType, string scope, string state, string codeChallenge)
        {
            ClientId = clientId;
            CodeChallengeMethod = codeChallengeMethod;
            RedirectUri = redirectUri;
            ResponseType = responseType;
            Scope = scope;
            State = state;
            CodeChallenge = codeChallenge;
        }

        [JsonPropertyName("client_id")]
        public string ClientId { get; } = "ownerapi";
        [JsonPropertyName("code_challenge_method")]
        public string CodeChallengeMethod { get; } = "S256";
        [JsonPropertyName("redirect_uri")]
        public string RedirectUri { get; } = "https://auth.tesla.com/void/callback";
        [JsonPropertyName("response_type")]
        public string ResponseType { get; } = "code";
        [JsonPropertyName("scope")]
        public string Scope { get; } = "openid email offline_access";
        [JsonPropertyName("state")]
        public string State { get; }
        [JsonPropertyName("code_challenge")]
        public string CodeChallenge { get; }
        
    }

    public static class AuthorizeEndPointRequestExtensions
    {
        public static string ConverToUri(this AuthorizeEndPointRequest options)
        {
            var properties = options.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false).Any());
            var sb = new StringBuilder();
            foreach (var item in properties)
            {
                var arguments = item.GetCustomAttributesData().FirstOrDefault(o => o.AttributeType == typeof(JsonPropertyNameAttribute))?.ConstructorArguments;
                if (arguments == null || arguments.Count < 1)
                {
                    continue;
                }
                var key = arguments[0].Value?.ToString();
                var value = item.GetValue(options)?.ToString();
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                {
                    continue;
                }
                if (sb.Length == 0)
                {
                    sb.Append($"{key}={value}");
                }
                else
                {
                    sb.Append($"&{key}={value}");
                }
            }
            return sb.ToString();
        }
    }
}
