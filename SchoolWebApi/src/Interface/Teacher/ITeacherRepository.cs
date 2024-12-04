using SchoolWebApi.src.Dto.Teacher;

namespace SchoolWebApi.src.Interface.Teacher
{
    public interface ITeacherRepository
    {
        public IQueryable<Model.Teacher>? Get();
        public Task<Model.Teacher?> GetById(long id);
        public Task<bool> Delete(long id);
        public Task<Model.Teacher?> UpdateAsync(UpdateTeacherDto input, long id);
        public Task<Model.Teacher?> CreateAsync(CreateTeacherDto input);
    }
}
