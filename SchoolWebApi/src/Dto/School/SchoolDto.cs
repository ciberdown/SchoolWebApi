using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Dto.School
{
    public class SchoolStudentDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string? Description { get; set; }
        public int? Age { get; set; }
    }

    public class SchoolCourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
    }
    public class SchoolDto : FullAuditDto<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<SchoolStudentDto>? Students { get; set; }
        public IEnumerable<SchoolCourseDto>? Courses { get; set; }

        public SchoolDto(Model.School school)
        {
            Id = school.Id;
            CreationTime = school.CreationTime;
            Name = school.Name;
            Description = school.Description;
            LastModificationTime = school.LastModificationTime;
            Students = school.Students?.Select(s =>
                new SchoolStudentDto
                {
                    Id = s.Id,
                    StudentName = s.Name,
                    Description = s.Description,
                    Age = s.Age
                }
            );
            Courses = school.Courses?.Select(c =>
                new SchoolCourseDto
                {
                    Id = c.Id,
                    CourseName = c.Name,
                    Description = c.Description,
                    SchoolId = c.SchoolId,
                }
            );
        }
    }
}
