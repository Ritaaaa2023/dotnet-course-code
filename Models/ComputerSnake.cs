namespace HelloWorld.Models
{
  public class ComputerSnake
  {
    public int computer_id { get; set; } // ✅ No warning — has default VALUE
    public string motherboard { get; set; } = ""; // ✅ No warning — has default VALUE 

    public int cpu_cores { get; set; }
    public bool has_wifi { get; set; }
    public DateTime? release_date { get; set; }
    public decimal price { get; set; }
    public string? video_card { get; set; } = "";


  }
}