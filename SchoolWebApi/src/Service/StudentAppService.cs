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

        public async Task<StudentDto?> CreateAsync(StudentCreateDto input)
        {
            var res = await _repo.CreateAsync(input);
            if (res == null)
                return null;
            var studentDto = new StudentDto(res);
            return studentDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _repo.DeleteAsync(id);
            return res;
        }

        public async Task<StudentDto?> UpdateAsync(StudentUpdateDto input, int id)
        {
            var res = await _repo.UpdateAsync(input, id);
            if(res == null)
                return null;
            var studentDto = new StudentDto(res);
            return studentDto;
        }
    }
}
