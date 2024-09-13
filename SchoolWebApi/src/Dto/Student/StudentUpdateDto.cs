namespace SchoolWebApi.src.Dto.Student
{
    public class StudentUpdateDto
    {
        public string? Name { get; set; }
        public int? SchoolId { get; set; }
        public string? Description { get; set; }
        public int? Age { get; set; }
        public DateTime LastModificationTime { get; set; }

        public StudentUpdateDto(string? name, int? schoolId, string? description, int? age)
        {
            Name = name;
            SchoolId = schoolId;
            Description = description;
            Age = age;
            LastModificationTime = DateTime.Now;
        }
    }
}
