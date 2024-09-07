namespace SchoolWebApi.src.Model
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int? Grade { get; set; }

        public StudentCourse(int studentId, int courseId, int? grade)
        {
            StudentId = studentId;
            CourseId = courseId;
            Grade = grade;
        }
    }
}
