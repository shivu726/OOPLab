using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Entities.StudentEnrollment> StudentEnrollments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=StudentEnrollment;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.StudentEnrollment>(entity =>
            {
                entity.HasKey(e => e.EnrollmentID);

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.StudentEnrollments)
                    .HasForeignKey(e => e.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(e => e.Course)
                    .WithMany(c => c.StudentEnrollments)
                    .HasForeignKey(e => e.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);


                entity.Property(e => e.EnrollmentDate)
                    .IsRequired();
            });
        }
    }
}
