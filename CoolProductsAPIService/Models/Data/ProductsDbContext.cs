using CoolProductsAPIService.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoolProductsAPIService.Models.Data
{
    public class ProductsDbContext : IdentityDbContext<IdentityUser>
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
            
        }

        public DbSet<Products> Products { get; set; }
    }
}
