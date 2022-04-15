﻿using FinalProjectIDS309.Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectIDS309.Backend.Context
{
    public class DBContextConfig : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=DbTodo;Integrated Security=True");
        }
    }
}
