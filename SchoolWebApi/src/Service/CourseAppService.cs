using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Course;
using SchoolWebApi.src.Repository;

namespace SchoolWebApi.src.Service
{
    public class CourseAppService : ICourseAppService
    {
        private ICourseRepo _repo { get; set; }

        public CourseAppService(ICourseRepo repo)
        {
            _repo = repo;
        }
        public async Task<PagedResultDto<CourseDto>> Get(BaseInputDto input)
        {
            var res = await _repo.Get().ToListAsync();
            var courseDtos = res.Select(c => new CourseDto(c));
            var pagedRes = new PagedResultDto<CourseDto>(courseDtos, input);
            return pagedRes;
        }

        public async Task<CourseDto?> GetById(int id)
        {
            var res = await _repo.GetById(id);
            if (res == null)
                return null;
            var courseDto = new CourseDto(res);
            return courseDto;
        }

        public async Task<CourseDto?> Update(CourseUpdateDto input, int id)
        {
            var res = await _repo.Update(input, id);
            if(res == null)
                return null;
            var courseDto = new CourseDto(res);
            return courseDto;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _repo.Delete(id);
            return res;
        }

        public async Task<CourseDto?> Create(CourseCreateDto input)
        {
            var res = await _repo.Create(input);
            var courseDto = new CourseDto(res);
            return courseDto;
        }
    }
}
