using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Student;
using SchoolWebApi.src.Repository;

namespace SchoolWebApi.src.Service
{
    public class StudentAppService : IStudentAppService
    {
        private IStudentRepo _repo {  get; set; }

        public StudentAppService(IStudentRepo repo)
        {
            _repo = repo;
        }
        public async Task<PagedResultDto<StudentDto>> GetAllAsync(BaseInputDto input)
        {
            var students = await _repo.GetAll().ToListAsync();
            var studentDtos = students.Select(s => new StudentDto(s));
            var pagedResult = new PagedResultDto<StudentDto>(studentDtos, input);
            return pagedResult;
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var res = await _repo.GetByIdAsync(id);
            if(res == null)
                return null;
            var studentDto = new StudentDto(res);
            return studentDto;
        }
    }
}
