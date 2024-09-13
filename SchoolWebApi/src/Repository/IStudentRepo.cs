using SchoolWebApi.src.Dto.Student;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public interface IStudentRepo
    {
        public IQueryable<Student> GetAll();
        public Task<Student?> GetByIdAsync(int id);
        public Task<Student?> CreateAsync(StudentCreateDto input);
        public Task<bool> DeleteAsync(int id);
        public Task<Student?> UpdateAsync(StudentUpdateDto input, int id);
    }
}
