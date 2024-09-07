namespace SchoolWebApi.src.Model
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<Student>? Students { get; set; }
        public IEnumerable<Course>? Courses { get; set; }

        public School(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}
