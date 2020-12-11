using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SwtorOptimizer.Models
{
    public class LoginRequest
    {
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}