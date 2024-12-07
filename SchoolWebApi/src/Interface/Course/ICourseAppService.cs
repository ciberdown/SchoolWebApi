using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Course;

namespace SchoolWebApi.src.Interface.Course
{
    public interface ICourseAppService
    {
        public Task<PagedResultDto<CourseDto>> Get(BaseInputDto input);
        public Task<CourseDto?> GetById(long id);
        public Task<bool> Delete(long id);
        public Task<CourseDto?> Update(UpdateCourseDto input, long id);
        public Task<CourseDto?> Create(CreateCourseDto input);
    }
}
