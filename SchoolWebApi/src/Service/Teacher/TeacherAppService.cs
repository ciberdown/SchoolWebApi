using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Teacher;
using SchoolWebApi.src.Interface.Teacher;

namespace SchoolWebApi.src.Service.Teacher
{
    public class TeacherAppService : ITeacherAppService
    {
        private readonly ITeacherRepository _repo;

        public TeacherAppService(ITeacherRepository repo)
        {
            _repo = repo;
        }

        public async Task<PagedResultDto<TeacherDto>> Get(BaseInputDto input)
        {
            var teachers = _repo.Get();
            var teacherDtos = teachers.Select(t => new TeacherDto(t));
            var pagedTeachers = await PagedResultDto<TeacherDto>.CreateAsync(teacherDtos, input);
            return pagedTeachers;
        }

        public async Task<TeacherDto?> GetById(long id)
        {
            var teacher = await _repo.GetById(id);
            if (teacher == null)
                return null;
            var teacherDto = new TeacherDto(teacher);
            return teacherDto;
        }

        public async Task<bool> Delete(long id)
        {
            var res = await _repo.Delete(id);
            return res;
        }

        public async Task<TeacherDto?> Create(CreateTeacherDto input)
        {
            var res = await _repo.CreateAsync(input);
            if (res == null)
                return null;
            var dto = new TeacherDto(res);
            return dto;
        }

        public async Task<TeacherDto?> Update(UpdateTeacherDto input, long id)
        {
            var res = await _repo.UpdateAsync(input, id);
            if (res == null)
                return null;
            var dto = new TeacherDto(res);
            return dto;
        }
    }
}
