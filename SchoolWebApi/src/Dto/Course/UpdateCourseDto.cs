namespace SchoolWebApi.src.Dto.Course
{
    public class UpdateCourseDto
    {
        public string? Name { get; set; }

        public long? SchoolId { get; set; }

        public long? TeacherId { get; set; }

        public UpdateCourseDto(string name, long? schoolId, long? teacherId)
        {
            Name = name;
            SchoolId = schoolId;
            TeacherId = teacherId;
        }
    }
}
