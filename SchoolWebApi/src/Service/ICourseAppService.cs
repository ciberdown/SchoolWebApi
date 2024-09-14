using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Course;

namespace SchoolWebApi.src.Service
{
    public interface ICourseAppService
    {
        public Task<PagedResultDto<CourseDto>> Get(BaseInputDto input);
        public Task<CourseDto?> GetById(int id);
        public Task<CourseDto?> Update(CourseUpdateDto input, int id);
        public Task<bool> Delete(int id);
        public Task<CourseDto?> Create(CourseCreateDto input);
    }
}
