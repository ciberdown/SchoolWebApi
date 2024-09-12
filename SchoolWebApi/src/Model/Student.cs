using SchoolWebApi.src.Dto;

namespace SchoolWebApi.src.Model
{
    public class Student : FullAuditDto<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Age { get; set; }
        
        public int SchoolId { get; set; }
        public School School { get; set; }

        public IEnumerable<StudentCourse>? Courses { get; set; }

        public Student(string name, string? description, int? age, int schoolId)
        {
            Name = name;
            Description = description;
            Age = age;
            SchoolId = schoolId;
            CreationTime = DateTime.Now;
        }
    }
}
