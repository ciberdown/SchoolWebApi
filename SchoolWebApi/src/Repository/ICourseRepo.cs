using SchoolWebApi.src.Dto.Course;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public interface ICourseRepo
    {
        public IQueryable<Course> Get();
        public Task<Course?> GetById(int id);
        public Task<Course?> Create(CourseCreateDto input);
        public Task<bool> Delete(int id);
        public Task<Course?> Update(CourseUpdateDto input, int id);
    }
}
