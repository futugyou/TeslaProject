using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TeslaApi.Contract.Authentication
{
    public class AccessTokenRequest
    {
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; } = "urn:ietf:params:oauth:grant-type:jwt-bearer";
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; } = "81527cff06843c8634fdc09e8ac0abefb46ac849f38fe1e431c2ef2106796384";
        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; } = "c7257eb71a564034f9419ee651c7d0e5f7aa6bfbd18bafb5c5c033b093bb2fa3";
    }

    public class AccessTokenResponse
    {
        [JsonPropertyName("response")]
        public string Response { get; set; } = "";
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = "";
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = "";
        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = "";
        [JsonPropertyName("created_at")]
        public int? CreatedAt { get; set; }
    }
}
