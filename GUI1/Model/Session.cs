using System;
using System.Text.Json.Serialization;

namespace GUI1.Model
{
    internal class Session
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("valid_until")]
        public DateTime ValidUntil { get; set; }
    }
}
