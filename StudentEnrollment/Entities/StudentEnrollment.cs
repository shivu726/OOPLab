

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEnrollment.Entities
{
    public class StudentEnrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EnrollmentID { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        public decimal Grade { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public List<StudentEnrollment> StudentEnrollments { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string CourseDescription { get; set; }

        public List<StudentEnrollment> StudentEnrollments { get; set; }
    }
}
