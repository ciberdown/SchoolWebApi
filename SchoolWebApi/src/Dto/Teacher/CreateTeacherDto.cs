using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Dto.Teacher
{
    public class CreateTeacherDto
    {
        public string Name { get; set; }
        public long? SchoolId { get; set; }

        public CreateTeacherDto(string name, long? schoolId)
        {
            Name = name;
            SchoolId = schoolId;
        }
    }
}
