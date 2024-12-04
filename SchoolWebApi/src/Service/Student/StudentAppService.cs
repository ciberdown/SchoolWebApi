using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Student;
using SchoolWebApi.src.Interface.Student;

namespace SchoolWebApi.src.Service.Student
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentRepository _repo;

        public StudentAppService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<PagedResultDto<StudentDto>> Get(BaseInputDto input)
        {
            var students= _repo.Get();
            var studentDtos = students.Select(s => new StudentDto(s));
            var pagedStudents = await PagedResultDto<StudentDto>.CreateAsync(studentDtos, input);
            return pagedStudents;
        }

        public async Task<StudentDto?> GetById(long id)
        {
            var student = await _repo.GetById(id);
            if (student == null)
                return null;
            var studentDto = new StudentDto(student);
            return studentDto;
        }

        public async Task<bool> Delete(long id)
        {
            var res = await _repo.Delete(id);
            return res;
        }

        public async Task<StudentDto?> Create(CreateStudentDto input)
        {
            var res = await _repo.CreateAsync(input);
            if (res == null)
                return null;
            var dto = new StudentDto(res);
            return dto;
        }

        public async Task<StudentDto?> Update(UpdateStudentDto input, long id)
        {
            var res = await _repo.UpdateAsync(input, id);
            if (res == null)
                return null;
            var dto = new StudentDto(res);
            return dto;
        }
    }
}
