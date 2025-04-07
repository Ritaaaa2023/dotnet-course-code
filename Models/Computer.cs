namespace HelloWorld.Models
{
    public class Computer
    {
        public string Motherboard { get; set; } = ""; // ✅ No warning — has default VALUE 

        public int CPUCores { get; set; }
        public bool HasWifi { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string? VideoCard { get; set; }
    }
}