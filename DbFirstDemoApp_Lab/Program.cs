using DbFirstDemoApp_Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstDemoApp_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentsEnrollContext())
            {
                var student = context.Students
                                        .Include(e => e.Enrollments)
                                        .FirstOrDefault(s => s.StudentId == 2);

                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();

                    Console.WriteLine("Data deleted successfully.");
                }
            }

            //CreateStudentEnrollment();

                //EnrollStudents();
        }

        private static void CreateStudentEnrollment()
        {
            using (var context = new StudentsEnrollContext())
            {
                var std = new Student
                {
                    FirstName = "Smith",
                    LastName = "Lee",
                    EnrollmentDate = DateTime.Now,
                    Email = "smit@example.com"
                };

                context.Students.Add(std);
                context.SaveChanges();

                var enroll = new Enrollment()
                {
                    StudentId = std.StudentId,
                    CourseId = 1,
                    Grade = 85
                };

                context.Enrollments.Add(enroll);
                context.SaveChanges();

                Console.WriteLine("Data added successfully.");
            }
        }

        private static void EnrollStudents()
        {
            using (var context = new StudentsEnrollContext())
            {
                var students = context.Students
                                        .Include(e => e.Enrollments)
                                        .ThenInclude(c => c.Course).ToList();

                foreach (var student in students)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");

                    foreach (var enroll in student.Enrollments)
                    {
                        Console.WriteLine($"Enrolled in: {enroll.Course.Title}, Grade: {enroll.Grade}");
                    }
                }
            }
        }
    }
}
