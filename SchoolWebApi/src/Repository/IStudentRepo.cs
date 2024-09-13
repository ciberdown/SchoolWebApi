using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public interface IStudentRepo
    {
        public IQueryable<Student> GetAll();
        public Task<Student?> GetByIdAsync(int id);
    }
}
