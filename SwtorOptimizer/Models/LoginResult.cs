using System.Text.Json.Serialization;

namespace SwtorOptimizer.Models
{
    public class LoginResult
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("originalUserName")]
        public string OriginalUserName { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}