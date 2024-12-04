using System.ComponentModel.DataAnnotations;

namespace SchoolWebApi.src.Model
{
    public class StudentCourse
    {
        public long StudentId { get; set; }
        public Student Student { get; set; }

        public long CourseId { get; set; }
        public Course Course { get; set; }

        [Range(0, 20,ErrorMessage = "Grade must be between 0 and 20.")]
        public int? Grade { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public bool IsDeleted { get; set; } = false;

        public StudentCourse(long studentId, long courseId, int? grade)
        {
            StudentId = studentId;
            CourseId = courseId;
            Grade = grade;
            CreationTime = DateTime.Now;
        }
    }


}
