namespace SchoolWebApi.src.Dto.Student
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public string? Description { get; set; }
        public int? Age { get; set; }

        public StudentCreateDto(string name, int schoolId, string? description, int? age)
        {
            Name = name;
            SchoolId = schoolId;
            Description = description;
            Age = age;
        }
    }
}
