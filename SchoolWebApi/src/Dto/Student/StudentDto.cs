
namespace SchoolWebApi.src.Dto.Student
{
    public class StudentCourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string? CourseDescription { get; set; }
    }
    public class StudentSchoolDto
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string? SchoolDescription { get; set; }
    }
    public class StudentDto : FullAuditDto<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Age { get; set; }

        public StudentSchoolDto School { get; set; }

        public IEnumerable<StudentCourseDto>? Courses { get; set; }

        public StudentDto(Model.Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Description = student.Description;
            Age = student.Age;
            CreationTime = student.CreationTime;
            LastModificationTime = student.LastModificationTime;
            School = new StudentSchoolDto
            {
                SchoolId = student.SchoolId,
                SchoolDescription = student.School.Description,
                SchoolName = student.School.Name
            };
            Courses = student.Courses?.Select(sc => new StudentCourseDto
                {
                    CourseId = sc.CourseId,
                    CourseName = sc.Course.Name,
                    CourseDescription = sc.Course.Description
                }
            );
        }
    }
}
