using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GUI1.Model
{
    public class Player
    {
        
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
        [JsonPropertyName("gold")]
        public int Gold { get; set; }
        [JsonPropertyName("experience_points")]
        public int Experience { get; set; }
        [JsonPropertyName("strength")]
        public int Strength { get; set; }
        [JsonPropertyName("intelligence")]
        public int Intelligence { get; set; }
        [JsonPropertyName("max_health")]
        public int MaxHP { get; set; }
        [JsonPropertyName("current_health")]
        public int CurrentHP { get; set; }
        [JsonPropertyName("max_experience_points")]
        public int MaxExperience { get; set; }
        [JsonPropertyName("x")]
        public int X { get; set; }
        [JsonPropertyName("y")]
        public int Y { get; set; }
        
    }
}
