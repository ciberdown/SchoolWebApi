namespace SchoolWebApi.src.Dto.Teacher
{
    public class UpdateTeacherDto
    {
        public string Name { get; set; }
        public long? SchoolId { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}
