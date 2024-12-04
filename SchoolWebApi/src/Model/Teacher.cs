using SchoolWebApi.src.Dto;

namespace SchoolWebApi.src.Model
{
    public class Teacher: FullAuditDto<long>
    {
        public string Name { get; set; }

        public IEnumerable<Course>? Courses { get; set; }
        
        public long? SchoolId { get; set; }
        public School School { get; set; }

        public Teacher(string name, long? schoolId)
        {
            Name = name;
            SchoolId = schoolId;
            CreationTime = DateTime.Now;
        }
    }

}
