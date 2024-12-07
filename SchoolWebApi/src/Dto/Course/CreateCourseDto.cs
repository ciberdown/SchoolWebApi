using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Dto.Course
{
    public class CreateCourseDto
    {
        public string Name { get; set; }

        public long? SchoolId { get; set; }

        public long? TeacherId { get; set; }

        public CreateCourseDto(string name, long? schoolId, long? teacherId)
        {
            Name = name;
            SchoolId = schoolId;
            TeacherId = teacherId;
        }
    }
}
