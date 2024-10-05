using CoolProductsAPIService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoolProductsAPIService.Models.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
            
        }

        public DbSet<Products> Products { get; set; }
    }
}
