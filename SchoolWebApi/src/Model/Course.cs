namespace SchoolWebApi.src.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
        
        public int SchoolId { get; set; }
        public School School { get; set; }

        public IEnumerable<StudentCourse>? Students { get; set; }

        public Course(string name, string? description, int schoolId)
        {
            Name = name;
            Description = description;
            SchoolId = schoolId;
        }
    }
}
