using System.Text.Json.Serialization;

namespace SwtorOptimizer.Models
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}