using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.StudentCourse;
using SchoolWebApi.src.Repository;

namespace SchoolWebApi.src.Service
{
    public class StudentCourseAppService : IStudentCourseAppService
    {
        private IStudentCourseRepo _repo { get; set; }

        public StudentCourseAppService(IStudentCourseRepo repo)
        {
            _repo = repo;
        }
        public async Task<PagedResultDto<StudentCourseDto>> Get(BaseInputDto input)
        {
            var res = await _repo.Get();
            var dtos = res.Select(sc => new StudentCourseDto(sc)).ToList();
            var pagedRes = new PagedResultDto<StudentCourseDto>(dtos, input);
            return pagedRes;
        }

        public async Task<StudentCourseDto?> GetById(int studentId, int courseId)
        {
            var res = await _repo.GetById(studentId, courseId);
            if (res == null)
                return null;
            var dto = new StudentCourseDto(res);
            return dto;
        }

        public async Task<bool> Delete(int studentId, int courseId)
        {
            return await _repo.Delete(studentId, courseId);
        }

        public async Task<StudentCourseDto?> Update(StudentCourseUpdateDto input, int studentId, int courseId)
        {
            var res = await _repo.Update(input, studentId, courseId);
            if (res == null)
                return null;
            var created = await _repo.GetById(studentId, courseId);
            var dto = new StudentCourseDto(created);
            return dto;
        }

        public async Task<StudentCourseDto?> Create(StudentCourseCreateDto input)
        {
            var res = await _repo.Create(input);
            if (res == null)
                return null;
            var created = await _repo.GetById(input.StudentId, input.CourseId);
            var dto = new StudentCourseDto(created);
            return dto;
        }
    }
}
