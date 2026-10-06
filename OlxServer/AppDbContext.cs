using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using OlxServer.Models;

namespace OlxServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                  Database=OlxOnlineShopDb;
                  Trusted_Connection=True;
                  TrustServerCertificate=True;");
        }
    }
}