using SchoolWebApi.src.Dto;

namespace SchoolWebApi.src.Model
{
    public class Course : FullAuditDto<long>
    {
        public string Name { get; set; }
        
        public long? SchoolId { get; set; }
        public School? School { get; private set; }

        public long? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public IEnumerable<StudentCourse>? Students { get; set; }

        public Course(string name, long? schoolId, long? teacherId)
        {
            Name = name;
            SchoolId = schoolId;
            CreationTime = DateTime.Now;
            TeacherId = teacherId;
        }
    }

}
