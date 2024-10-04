using KnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
    public class KnowledgeHubPortalDbContext : DbContext
    {
        public KnowledgeHubPortalDbContext()
        {
            
        }

        public KnowledgeHubPortalDbContext(DbContextOptions<KnowledgeHubPortalDbContext> options)
        {
            // for configuring database from config file..
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // for configuring database from hardcoded connection string..

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=KnowledgeHubPortalApp;Integrated Security=True;MultipleActiveResultSets=True").UseLazyLoadingProxies().LogTo(Console.WriteLine, LogLevel.Information);
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
