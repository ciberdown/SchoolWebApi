using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.StudentCourse;

namespace SchoolWebApi.src.Service
{
    public interface IStudentCourseAppService
    {
        public Task<PagedResultDto<StudentCourseDto>> Get(BaseInputDto input);
        public Task<StudentCourseDto?> GetById(int studentId, int courseId);
        public Task<bool> Delete(int studentId, int courseId);
        public Task<StudentCourseDto?> Update(StudentCourseUpdateDto input, int studentId, int courseId);
        public Task<StudentCourseDto?> Create(StudentCourseCreateDto input);
    }
}
