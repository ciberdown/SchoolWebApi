using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Student;

namespace SchoolWebApi.src.Service
{
    public interface IStudentAppService
    {
        public Task<PagedResultDto<StudentDto>> GetAllAsync(BaseInputDto input);
        public Task<StudentDto?> GetByIdAsync(int id);
    }
}
