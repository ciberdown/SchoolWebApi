using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Dto.Course
{
    public class CourseSchoolDto
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string? SchoolDescription { get; set; }
    }

    public class CourseStudentsDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string? StudentDescription { get; set; }
        public int? StudentGrade { get; set; }
    }
    public class CourseDto : FullAuditDto<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }


        public CourseSchoolDto School { get; set; }

        public IEnumerable<CourseStudentsDto>? Students { get; set; }

        public CourseDto(Model.Course course)
        {
            Id = course.Id;
            Name = course.Name;
            Description = course.Description;
            School = new CourseSchoolDto
            {
                Id = course.SchoolId,
                SchoolName = course.School.Name,
                SchoolDescription = course.School.Description,
            };
            Students = course.Students?.Select(s =>
            {
                return new CourseStudentsDto
                {
                    StudentId = s.StudentId,
                    StudentDescription = s.Student?.Description,
                    StudentGrade = s.Grade,
                    StudentName = s.Student?.Name
                };
            });
            LastModificationTime = course.LastModificationTime;
            CreationTime = course.CreationTime;
        }
    }
}
