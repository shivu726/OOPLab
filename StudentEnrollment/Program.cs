using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using StudentEnrollment.Entities;

namespace StudentEnrollment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (SchoolDbContext _db = new SchoolDbContext())
            {
                var enrollStd = _db.StudentEnrollments.Find(1003);

                _db.StudentEnrollments.Remove(enrollStd);
                _db.SaveChanges();
                Console.WriteLine("Sucessfully deleted..");
            }
        }

        private static void GetStudentEnrollment()
        {
            using (SchoolDbContext _db = new SchoolDbContext())
            {
                var stdEnrolls = _db.StudentEnrollments.Include(x => x.Course).Include(s => s.Student).ToList();

                foreach (var item in stdEnrolls)
                {
                    Console.WriteLine($"Details - Student Name: {item.Student.Name}, Email: {item.Student.Email}, CourseName: {item.Course.Name}, Grade: {item.Grade}");
                }
            }
        }

        private static void AddStudentEnrollment()
        {
            using (SchoolDbContext _db = new SchoolDbContext())
            {
                var std = new Student()
                {
                    Name = "Aman",
                    Age = 29,
                    Email = "aman@example.com"
                };

                var course = new Course() { Name = "Node Js", CourseDescription = "Node Js course." };

                var stdEnroll = new Entities.StudentEnrollment()
                {
                    Student = std,
                    Course = course,
                    Grade = 90,
                    EnrollmentDate = DateTime.Now
                };

                _db.StudentEnrollments.Add(stdEnroll);
                _db.SaveChanges();
                Console.WriteLine("Students created successfully.");
            }
        }
    }
}
