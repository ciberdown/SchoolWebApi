using SchoolWebApi.src.Dto;

namespace SchoolWebApi.src.Model
{
    public class Course : FullAuditDto<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        
        
        public int SchoolId { get; set; }
        public School School { get; set; }

        public IEnumerable<StudentCourse>? Students { get; set; }

        public Course(string name, string? description, int schoolId, DateTime creationTime, DateTime? lastModificationTime = null)
        {
            Name = name;
            Description = description;
            SchoolId = schoolId;
            CreationTime = creationTime;
            LastModificationTime = lastModificationTime;
        }
    }
}
