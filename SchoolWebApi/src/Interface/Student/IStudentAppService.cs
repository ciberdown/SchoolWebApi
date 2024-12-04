using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Student;

namespace SchoolWebApi.src.Interface.Student
{
    public interface IStudentAppService
    {
        public Task<PagedResultDto<StudentDto>> Get(BaseInputDto input);
        public Task<StudentDto?> GetById(long id);
        public Task<bool> Delete(long id);
        public Task<StudentDto?> Create(CreateStudentDto input);
        public Task<StudentDto?> Update(UpdateStudentDto input, long id);

    }
}
