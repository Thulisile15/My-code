using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Infrastructure.Models;

namespace MyFirstAPI.Infrastructure
{
    public class MyFirstAPIDBContext: DbContext
    {
        private readonly static string CONN_STRING = "Server=LAPTOP-BM58RI3I\\SQLEXPRESS02;Database=TestingAPI_ToDo(1);User=test_db_user1;Password=p@55w0rd;TrustServerCertificate=True;";

        public MyFirstAPIDBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONN_STRING);
        }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoCategory> ToDoCategories { get; set; }
    }
}
