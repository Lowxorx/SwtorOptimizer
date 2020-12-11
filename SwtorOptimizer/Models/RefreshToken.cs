using System;
using System.Text.Json.Serialization;

namespace SwtorOptimizer.Models
{
    public class RefreshToken
    {
        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }

        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}