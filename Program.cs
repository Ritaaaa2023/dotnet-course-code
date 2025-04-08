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
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
      // string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=True;";
      // IDbConnection dbConnection = new SqlConnection(connectionString);
      // string sqlCommand = "SELECT GETDATE()";
      IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsetting.json" )
        .Build();
       
      DatacontextDapper dapper = new DatacontextDapper(config);

      string computersJson = File.ReadAllText("ComputersSnake.json");
      
      // Mapper mapper = new Mapper(new MapperConfiguration((cfg)=>{
      //   cfg.CreateMap<ComputerSnake,Computer>()
      //     .ForMember(destination => destination.ComputerId, opt => opt.MapFrom(src => src.computer_id))
      //   .ForMember(destination => destination.Motherboard, opt => opt.MapFrom(src => src.motherboard))
      //   .ForMember(destination => destination.CPUCores, opt => opt.MapFrom(src => src.cpu_cores))
      //   .ForMember(destination => destination.HasWifi, opt => opt.MapFrom(src => src.has_wifi))
      //   .ForMember(destination => destination.ReleaseDate, opt => opt.MapFrom(src => src.release_date))
      //   .ForMember(destination => destination.Price, opt => opt.MapFrom(src => src.price * .8m))
      //   .ForMember(destination => destination.VideoCard, opt => opt.MapFrom(src => src.video_card));   
      // }));

       IEnumerable<Computer>? computerSystem = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);
      if(computerSystem != null)
      {
        // IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computerSystem);

        foreach(Computer computer in computerSystem)
        {
          Console.WriteLine($"Motherboard: {computer.Motherboard}");
        }
      }


      // string  computersJson = File.ReadAllText("Computers.json");
      // Console.WriteLine(computersJson);

      // JsonSerializerOptions options = new JsonSerializerOptions()
      // {
      //   PropertyNameCaseInsensitive = true,
      //   WriteIndented = true
      // };

      //  IEnumerable<Computer>? computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);


      // if(computers != null)
      // {
      //   foreach(Computer computer in computers)
      //   {
      //     // Console.WriteLine($"Motherboard: {computer.Motherboard}");
      //     string sql = @"INSERT INTO TutorialAppSchema.Computer (Motherboard, CPUCores, HasWifi, ReleaseDate, Price, VideoCard) VALUES(
      //  '" + EscapeSingleQuotes(computer.Motherboard ?? string.Empty) + "','" + computer.CPUCores + "','" + computer.HasWifi + "','" + computer.ReleaseDate + "','" + computer.Price + "','" + EscapeSingleQuotes(computer.VideoCard ?? string.Empty) + "')";
      //       dapper.ExecuteSql(sql);

      //   }
      // }

    //   JsonSerializerSettings settings = new JsonSerializerSettings()
    //     {
    //      ContractResolver = new CamelCasePropertyNamesContractResolver()
    //     };

    //     string computercopy = JsonConvert.SerializeObject(computers,settings);

    //     File.WriteAllText("ComputersCopy.txt", computercopy);
    // // }

    // static string EscapeSingleQuotes(string input)
    // {
    //   string output = input.Replace("'", "''");
    //   return output;
    // }





    // DataContextEF entityFramework = new DataContextEF(config);


    //   DateTime rightNow = dapper.LoadDatasingle<DateTime>("SELECT GETDATE()");
    //   Console.WriteLine(rightNow);

    //   Computer computer = new Computer()

    //   {
    //     Motherboard = "Asus",
    //     CPUCores = 8,
    //     HasWifi = true,
    //     ReleaseDate = DateTime.Now,
    //     Price = 999.99m,
    //     VideoCard = "NVIDIA RTX 3080"
    //   };

    //   entityFramework.Add(computer);
    //   entityFramework.SaveChanges();




    //   // computer.HasWifi = false;
    //   // Console.WriteLine($"Motherboard: {computer.Motherboard}");
    //   // Console.WriteLine($"CPU Cores: {computer.CPUCores}");
    //   // Console.WriteLine($"Has Wifi: {computer.HasWifi}");
    //   // Console.WriteLine($"Release Date: {computer.ReleaseDate}");
    //   // Console.WriteLine($"Price: {computer.Price}");
    //   // Console.WriteLine($"Video Card: {computer.VideoCard}");

    //   string sql = @"INSERT INTO TutorialAppSchema.Computer (Motherboard, CPUCores, HasWifi, ReleaseDate, Price, VideoCard) VALUES(
    //   '" + computer.Motherboard + "','" + computer.CPUCores + "','" + computer.HasWifi + "','" + computer.ReleaseDate + "','" + computer.Price + "','" + computer.VideoCard + "')";
    //   bool result = dapper.ExecuteSql(sql);
    //   Console.WriteLine(result);

    //   string sqlSelect = @"
    //   SELECT

    //  Computer.ComputerId, Computer.Motherboard,  Computer.CPUCores,  Computer.HasWifi,  Computer.ReleaseDate,  Computer.Price,  Computer.VideoCard
    //   FROM TutorialAppSchema.Computer";

    //   IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);
    //   // IEnumerable<Computer>? computerEf = entityFramework.Computer?.ToList<Computer>();




    //   Console.WriteLine("'ComputerId','Motherboard','hasWifi','ReleaseDate','Price','VideoCard'");
    //   Console.WriteLine("--------------------------------------------------");


    //   foreach (Computer singleComputer in computers)
    //   {
    //     Console.WriteLine("'" + singleComputer.ComputerId + "', '" + "'" + singleComputer.Motherboard + "', '" + singleComputer.CPUCores + "', '" + singleComputer.HasWifi + "', '" + singleComputer.ReleaseDate + "', '" + singleComputer.Price + "', '" + singleComputer.VideoCard + "'");

    //   }
    //   IEnumerable<Computer>? computerEf = entityFramework.Computer?.ToList<Computer>();

    //   if(computerEf != null)
    //   {
    //     Console.WriteLine("'ComputerId','Motherboard','hasWifi','ReleaseDate','Price','VideoCard'");
    //     Console.WriteLine("--------------------------------------------------");


    //     foreach (Computer singleComputer in computerEf)
    //     {
    //       Console.WriteLine("'" + singleComputer.ComputerId + "', '" + "'" + singleComputer.Motherboard + "', '" + singleComputer.CPUCores + "', '" + singleComputer.HasWifi + "', '" + singleComputer.ReleaseDate + "', '" + singleComputer.Price + "', '" + singleComputer.VideoCard + "'");

    //     }
    //   }


  }
}
}