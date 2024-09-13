using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Student;

namespace SchoolWebApi.src.Service
{
    public interface IStudentAppService
    {
        public Task<PagedResultDto<StudentDto>> GetAllAsync(BaseInputDto input);
        public Task<StudentDto?> GetByIdAsync(int id);
        public Task<StudentDto?> CreateAsync(StudentCreateDto input);
        public Task<bool> DeleteAsync(int id);
        public Task<StudentDto?> UpdateAsync(StudentUpdateDto input, int id);
    }
}
