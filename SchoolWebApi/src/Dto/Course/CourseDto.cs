using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Dto.Course
{
    public class CourseStudentDto
    {
        public long Id { get; set; }
        public string StudentName { get; set; }
    }
    public class CourseTeacherDto
    {
        public long? Id { get; set; }
        public string? TeacherName { get; set; }
    }
    public class CourseSchoolDto
    {
        public long? Id { get; set; }
        public string? SchoolName { get; set; }
    }
    public class CourseDto : FullAuditDto<long>
    {
        public string Name { get; set; }

        public CourseSchoolDto? School { get; private set; }

        public CourseTeacherDto? Teacher { get; set; }

        public IEnumerable<CourseStudentDto>? Students { get; set; }

        public CourseDto(Model.Course course)
        {
            Name = course.Name;
            Id = course.Id;
            CreationTime = course.CreationTime;
            LastModificationTime = course.LastModificationTime;
            Students = course.Students != null? course.Students?.Select(s => new CourseStudentDto { 
                Id = s.StudentId, 
                StudentName= s.Student.Name 
            }) : null;
            isDeleted = course.isDeleted;
            School = course.SchoolId != null ? new CourseSchoolDto
            {
                Id = course.School?.Id
                ,
                SchoolName = course.School?.Name
            } : null;
            Teacher = course.TeacherId != null ? new CourseTeacherDto
            {
                Id = course.Teacher?.Id,
                TeacherName = course.Teacher?.Name
            } : null;
        }
    }
}
