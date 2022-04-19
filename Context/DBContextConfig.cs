using FinalProjectIDS309.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectIDS309.Context
{
  public class DBContextConfig : DbContext
  {
    private IConfiguration _config { get; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ItemModel> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_config.GetConnectionString("DbConnection"));
    }

    public DBContextConfig(IConfiguration config)
    {
      _config = config;
    }
  }
}
