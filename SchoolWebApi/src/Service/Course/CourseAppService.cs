using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Course;
using SchoolWebApi.src.Interface.Course;

namespace SchoolWebApi.src.Service.Course
{
    public class CourseAppService : ICourseAppService
    {
        private ICourseRepository _repo;
        public CourseAppService(ICourseRepository repo)
        {
            _repo = repo;
        }
        public async Task<CourseDto?> Create(CreateCourseDto input)
        {
            var res = await _repo.Create(input);
            if(res == null) 
                return null;
            return new CourseDto(res);
        }

        public async Task<bool> Delete(long id)
        {
            var res = await _repo.Delete(id);
            return res;
        }

        public async Task<PagedResultDto<CourseDto>> Get(BaseInputDto input)
        {
            var courses = _repo.Get();
            if (courses == null)
                return null;
            var courseDtos = courses.Select(c => new CourseDto(c));
            var pagedRes = await PagedResultDto<CourseDto>.CreateAsync(courseDtos, input);
            return pagedRes;
        }

        public async Task<CourseDto?> GetById(long id)
        {
            var res = await _repo.GetById(id);
            if(res == null) return null;
            return new CourseDto(res);
        }

        public async Task<CourseDto?> Update(UpdateCourseDto input, long id)
        {
            var res = await _repo.Update(input, id);
            if(res == null) return null;
            return new CourseDto(res);
        }
    }
}
