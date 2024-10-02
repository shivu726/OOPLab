using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Data
{
    public class StudentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=StudentDemo;Integrated Security=True;Encrypt=True");
        }

        public DbSet<Student> Students { get; set; }
    }
}
