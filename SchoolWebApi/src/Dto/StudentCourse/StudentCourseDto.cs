namespace SchoolWebApi.src.Dto.StudentCourse
{
    public class SCStudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string? StudentDescription { get; set; }

    }

    public class SCCourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string? CourseDescription { get; set; }

    }
    public class StudentCourseDto
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public SCStudentDto Student { get; set; }

        public SCCourseDto Course { get; set; }

        public int? Grade { get; set; }

        public StudentCourseDto(Model.StudentCourse studentCourse)
        {
            SchoolId = studentCourse.Student.SchoolId;
            SchoolName = studentCourse.Student.School.Name;
            Student = new SCStudentDto
            {
                StudentId = studentCourse.StudentId,
                StudentName = studentCourse.Student.Name,
                StudentDescription = studentCourse.Student.Description,
            };
            Course = new SCCourseDto
            {
                CourseId = studentCourse.CourseId,
                CourseName = studentCourse.Course.Name,
                CourseDescription = studentCourse.Course.Description
            };
            Grade = studentCourse.Grade;
        }
    }
}
