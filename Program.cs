// using DotnetCourseCode.Basics;
// using System;
// Basics.Run();

using System;
using System.Data;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using HelloWorld.Data;

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
      // string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=True;";
      // IDbConnection dbConnection = new SqlConnection(connectionString);
      // string sqlCommand = "SELECT GETDATE()";
      DatacontextDapper dapper = new DatacontextDapper();
      DateTime rightNow = dapper.LoadDatasingle<DateTime>("SELECT GETDATE()");
      Console.WriteLine(rightNow);

      Computer computer = new Computer()

      {
        Motherboard = "Asus",
        CPUCores = 8,
        HasWifi = true,
        ReleaseDate = DateTime.Now,
        Price = 999.99m,
        VideoCard = "NVIDIA RTX 3080"
      };
      // computer.HasWifi = false;
      // Console.WriteLine($"Motherboard: {computer.Motherboard}");
      // Console.WriteLine($"CPU Cores: {computer.CPUCores}");
      // Console.WriteLine($"Has Wifi: {computer.HasWifi}");
      // Console.WriteLine($"Release Date: {computer.ReleaseDate}");
      // Console.WriteLine($"Price: {computer.Price}");
      // Console.WriteLine($"Video Card: {computer.VideoCard}");

      string sql = @"INSERT INTO TutorialAppSchema.Computer (Motherboard, CPUCores, HasWifi, ReleaseDate, Price, VideoCard) VALUES(
      '" + computer.Motherboard + "','" + computer.CPUCores + "','" + computer.HasWifi + "','" + computer.ReleaseDate + "','" + computer.Price + "','" + computer.VideoCard + "')";
      bool result = dapper.ExecuteSql(sql);
      Console.WriteLine(result);

      string sqlSelect = @"
      SELECT
       
     Computer.Motherboard,  Computer.CPUCores,  Computer.HasWifi,  Computer.ReleaseDate,  Computer.Price,  Computer.VideoCard
      FROM TutorialAppSchema.Computer";

      IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

      Console.WriteLine("'Motherboard','hasWifi','ReleaseDate','Price','VideoCard'");
      Console.WriteLine("--------------------------------------------------");


      foreach (Computer singleComputer in computers)
      {
        Console.WriteLine("'" + computer.Motherboard + "', '" + computer.CPUCores + "', '" + computer.HasWifi + "', '" + computer.ReleaseDate + "', '" + computer.Price + "', '" + computer.VideoCard + "'");
       
      }
    }
  }
}