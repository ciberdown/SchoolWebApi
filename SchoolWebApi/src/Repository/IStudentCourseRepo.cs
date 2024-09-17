using SchoolWebApi.src.Dto.StudentCourse;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public interface IStudentCourseRepo
    {
        public Task<List<StudentCourse>> Get();
        public Task<StudentCourse?> GetById(int studentId, int courseId);
        public Task<bool> Delete(int studentId, int courseId);
        public Task<StudentCourse?> Update(StudentCourseUpdateDto input, int studentId, int courseId);
        public Task<StudentCourse?> Create(StudentCourseCreateDto input);

    }
}
