namespace SchoolWebApi.src.Dto.Teacher
{
    public class TeacherSchoolDto
    {
        public long Id { get; set; }
        public string SchoolName { get; set; }
    }
    public class TeacherCourseDto
    {
        public long Id { get; set; }
        public string CourseName { get; set; }
    }
    public class TeacherDto : FullAuditDto<long>
    {
        public string Name { get; set; }
        public TeacherSchoolDto School { get; set; }
        public IEnumerable<TeacherCourseDto> Courses { get; set; }

        public TeacherDto(Model.Teacher teacher)
        {
            Id = teacher.Id;
            LastModificationTime = teacher.LastModificationTime;
            CreationTime = teacher.CreationTime;
            isDeleted = teacher.isDeleted;
            Name = teacher.Name;
            if (teacher.School != null)
                School = new TeacherSchoolDto
                {
                    Id = teacher.School.Id,
                    SchoolName = teacher.School.Name
                };
            if (teacher.Courses != null)
                Courses = teacher.Courses.Select(c => new TeacherCourseDto
                {
                    Id = c.Id,
                    CourseName = c.Name,
                });
        }
    }
}
