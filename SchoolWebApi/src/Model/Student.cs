using SchoolWebApi.src.Dto;

namespace SchoolWebApi.src.Model
{
    public class Student : FullAuditDto<long>
    {
        public string Name { get; set; }
        
        public long? SchoolId { get; set; }
        public School? School { get; set; }

        public IEnumerable<StudentCourse>? Courses { get; set; }

        public Student(string name, long? schoolId)
        {
            Name = name;
            SchoolId = schoolId;
        }

    }

}
