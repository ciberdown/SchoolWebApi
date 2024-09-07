using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public interface ISchoolRepo
    {
        public IQueryable<School> Get();
        public Task<School?> GetById(int id);
    }
}
