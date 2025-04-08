// using HelloWorld.Models;
// using System.Data;

// using Microsoft.Data.SqlClient;
// using Dapper;

using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
  public class DataContextEF : DbContext 
  {
    private IConfiguration _config;
    private string? _connectionString;
    public DataContextEF(IConfiguration config)
    {
      _config = config;
      // _connectionString = config.GetConnectionString("DefaultConnection");
    }
    public DbSet<Computer> Computer { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
        options => options.EnableRetryOnFailure());
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Computer>(entity =>
      {
         modelBuilder.HasDefaultSchema("TutorialAppSchema");
         modelBuilder.Entity<Computer>()
          // .HasNoKey();
          .HasKey(c=>c.ComputerId);
        // Specify the table name and schema if needed
        // entity.ToTable("Computer", "TutorialAppSchema");
        
      });
    }
  }
  } 