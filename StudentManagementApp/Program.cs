using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;
using StudentManagementApp.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new StudentContext())
            //{
            //    //var students = context.Students.Where(a => a.Age > 20).ToList();

            //    //foreach (var std in students)
            //    //{
            //    //    Console.WriteLine($"ID:{std.Id}, Name:{std.Name}, Age: {std.Age}, Email: {std.Email} ");
            //    //}

            //    // Sorting students..

            //    int pageNumber = 1;
            //    int pageSize = 5;

            //    var student = context.Students.OrderBy(x => x.Name).Skip((pageNumber - 1) * pageSize)
            //                    .Take(pageSize).ToList();

            //    foreach (var std in student)
            //    {
            //        Console.WriteLine($"ID:{std.Id}, Name:{std.Name}, Age: {std.Age}, Email: {std.Email} ");
            //    }
            //    Console.ReadLine();
            //}



            //DeleteStudent();

            //UpdateStudentDetails();

            //GetStudentDetails();

            //CreateStudent();

            //CreateMultipleStudent();

            //UpdateMultipleStudent();

            HandleConcurrancy();
        }

        private static void DeleteStudent()
        {
            using (StudentContext dbContext = new StudentContext())
            {
                var student = dbContext.Students.FirstOrDefault(x => x.Name == "John Doe");

                if (student != null)
                {
                    dbContext.Students.Remove(student);

                    dbContext.SaveChanges();

                    Console.WriteLine("Student record deleted.");
                }
            }
        }

        private static void UpdateStudentDetails()
        {
            using (StudentContext dbContext = new StudentContext())
            {
                var student = dbContext.Students.FirstOrDefault(x => x.Name == "John Doe");

                if (student != null)
                {
                    student.Age = 32;

                    dbContext.SaveChanges();

                    Console.WriteLine("Student record updated.");
                }
            }
        }

        private static void GetStudentDetails()
        {
            using (StudentContext dbContext = new StudentContext())
            {
                var student = dbContext.Students.ToList();

                foreach (var std in student)
                {
                    Console.WriteLine($"ID:{std.Id}, Name:{std.Name}, Age: {std.Age}, Email: {std.Email} ");
                }
            }
        }

        private static void CreateStudent()
        {

            Student student = new Student()
            {
                Name = "Andrew Tie",
                Age = 17,
                Email = "andrew.tie@example.com"
            };

            var context = new ValidationContext(student, null, null);

            var result = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(student, context, result, true);

            if (isValid)
            {
                using (StudentContext dbContext = new StudentContext())
                {
                    dbContext.Students.Add(student);

                    dbContext.SaveChanges();
                    Console.WriteLine("Student record added.");
                }
            }
            else
            {
                foreach (var validationResult in result)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
        }

        private static void CreateMultipleStudent()
        {
            using (var context = new StudentContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var students = new List<Student>()
                        {
                            new Student() { Name = "Shivu", Age = 32, Email = "shiv@example.com" },
                            new Student() { Name = "Abhi", Age = 27, Email = "abhi@example.com" },
                            new Student() { Name = "Amar", Age = 29, Email = "amar@example.com" },
                            new Student() { Name = "Amith", Age = 20, Email = "amit@example.com" }
                        };

                        context.Students.AddRange(students);
                        context.SaveChanges();

                        transaction.Commit();
                        Console.WriteLine("Students added successfully.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Transaction failed: {ex.Message}");
                    }
                }
            }
        }

        private static void UpdateMultipleStudent()
        {
            using (var context = new StudentContext())
            {
                var students = context.Students.ToList();

                foreach (var student in students)
                {
                    student.Email = student.Email.Replace("@example.com", "@newdomain.com");
                }

                context.SaveChanges();
                Console.WriteLine("Bulk update completed.");
            }
        }

        private static void HandleConcurrancy ()
        {
            using (var context = new StudentContext())
            {
                var student = context.Students.FirstOrDefault(n => n.Name == "Shivu");

                if(student != null)
                {
                    student.Age = 22;

                    try
                    {
                        context.SaveChanges();
                        Console.WriteLine("Student record updated.");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Concurancy conflict detected. Please refresh and try again");
                    }
                }
            }
        }
    }
}
