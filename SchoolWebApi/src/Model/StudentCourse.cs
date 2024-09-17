namespace SchoolWebApi.src.Model
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int? Grade { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }

        public StudentCourse(int studentId, int courseId, int? grade, DateTime creationTime, DateTime? lastModificationTime = null)
        {
            StudentId = studentId;
            CourseId = courseId;
            Grade = grade;
            CreationTime = creationTime;
            LastModificationTime = lastModificationTime;
        }
    }
}
