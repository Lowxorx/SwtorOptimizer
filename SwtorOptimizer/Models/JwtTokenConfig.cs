using System.Text.Json.Serialization;

namespace SwtorOptimizer.Models
{
    public class JwtTokenConfig
    {
        [JsonPropertyName("accessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }

        [JsonPropertyName("secret")]
        public string Secret { get; set; }
    }
}