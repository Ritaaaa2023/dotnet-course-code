using System.Text.Json.Serialization;

namespace HelloWorld.Models
{
    public class Computer
    {
        [JsonPropertyName("computer_id")]
        public int ComputerId { get; set; } // ✅ No warning — has default VALUE
        [JsonPropertyName("motherboard")]
        public string Motherboard { get; set; } = ""; // ✅ No warning — has default VALUE 
[JsonPropertyName("cpu_cores")]
        public int CPUCores { get; set; }
        [JsonPropertyName("has_wifi")]
        public bool HasWifi { get; set; }
        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("video_card")]
        public string? VideoCard { get; set; } ="";


    }
}