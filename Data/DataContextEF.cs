using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Data
{
  public class DataContextEF: DbContext
  {
    public DataContextEF(DbContextOptions<DataContextEF> options) : base(options)
    {
    }

    public DbSet<Computer> Computers { get; set; } = null!;
  }
} 