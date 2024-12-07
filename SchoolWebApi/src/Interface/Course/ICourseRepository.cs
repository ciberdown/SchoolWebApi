using SchoolWebApi.src.Dto.Course;

namespace SchoolWebApi.src.Interface.Course
{
    public interface ICourseRepository
    {
        public IQueryable<Model.Course> Get();
        public Task<Model.Course?> GetById(long id);
        public Task<Model.Course?> Create(CreateCourseDto input);
        public Task<Model.Course?> Update(UpdateCourseDto input, long id);
        public Task<bool> Delete(long id);
        
    }
}
