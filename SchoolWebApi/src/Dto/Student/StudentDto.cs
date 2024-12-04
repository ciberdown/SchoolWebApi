namespace SchoolWebApi.src.Dto.Student
{
    public class StudentSchoolDto
    {
        public long Id { get; set; }
        public string SchoolName { get; set; }
    }
    public class StudentSCDto
    {
        public long Id { get; set; }
        public string CourseName { get; set; }
    }
    public class StudentDto : FullAuditDto<long>
    {
        public string Name { get; set; }
        public StudentSchoolDto School { get; set; }
        public IEnumerable<StudentSCDto> Courses { get; set; }
        
        public StudentDto(Model.Student student)
        {
            Id = student.Id;
            isDeleted = student.isDeleted;
            LastModificationTime = student.LastModificationTime;
            CreationTime = student.CreationTime;
            Name = student.Name;
            if(student.School != null)
                School = new StudentSchoolDto { 
                    Id = student.School.Id, 
                    SchoolName = student.School.Name };
            if(student.Courses != null)
                Courses = student.Courses.Select(c => new StudentSCDto
                {
                    Id = c.CourseId,
                    CourseName = c.Course.Name,
                });
        }
    }
}
