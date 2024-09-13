using SchoolWebApi.src.Dto;

namespace SchoolWebApi.src.Model
{
    public class School : FullAuditDto<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<Student>? Students { get; set; }
        public IEnumerable<Course>? Courses { get; set; }

        public School(string name, string? description, DateTime? lastModificationTime = null)
        {
            Name = name;
            Description = description;
            CreationTime = DateTime.Now;
            LastModificationTime = lastModificationTime;
        }
    }
}
