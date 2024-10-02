using Microsoft.EntityFrameworkCore;
using ProductsManagement.Entities;

namespace ProductsManagement.Data
{
    public class ProductsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ProductDemo;Integrated Security=True;Encrypt=True";

            optionsBuilder.UseSqlServer(connStr).LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

            // configure and map entities calss with tables
        public DbSet<Product> Products { get; set; }
    }
}
