using SchoolWebApi.src.Dto.Student;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Teacher;

namespace SchoolWebApi.src.Interface.Teacher
{
    public interface ITeacherAppService
    {
        public Task<PagedResultDto<TeacherDto>> Get(BaseInputDto input);
        public Task<TeacherDto?> GetById(long id);
        public Task<bool> Delete(long id);
        public Task<TeacherDto?> Create(CreateTeacherDto input);
        public Task<TeacherDto?> Update(UpdateTeacherDto input, long id);

    }
}
