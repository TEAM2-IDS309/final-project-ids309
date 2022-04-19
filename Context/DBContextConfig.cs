using FinalProjectIDS309.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectIDS309.Context
{
    public class DBContextConfig : DbContext
    {
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ItemModel> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=DbTodo;Integrated Security=True");
        }
    }
}
