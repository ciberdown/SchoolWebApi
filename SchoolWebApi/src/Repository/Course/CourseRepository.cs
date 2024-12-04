using SchoolWebApi.src.Data;
using SchoolWebApi.src.Interface.Course;

namespace SchoolWebApi.src.Repository.Course
{
    public class CourseRepository : BaseRepo, ICourseRepository
    {
        public CourseRepository(SchoolDb context) : base(context) { }
        
        
    }
}
