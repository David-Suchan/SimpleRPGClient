using System.Text.Json.Serialization;

namespace GUI1.Model
{
    internal class UserInfo
    {
        [JsonPropertyName("email") ]
        public string Email { get; set; }
        [JsonPropertyName("display_name")]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
}
