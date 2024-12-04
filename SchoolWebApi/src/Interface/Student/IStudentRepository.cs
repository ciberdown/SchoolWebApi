
using SchoolWebApi.src.Dto.Student;

namespace SchoolWebApi.src.Interface.Student
{
    public interface IStudentRepository
    {
        public IQueryable<Model.Student>? Get();
        public Task<Model.Student?> GetById(long id);
        public Task<bool> Delete(long id);
        public Task<Model.Student?> UpdateAsync(UpdateStudentDto input, long id);
        public Task<Model.Student?> CreateAsync(CreateStudentDto input);
    }
}
