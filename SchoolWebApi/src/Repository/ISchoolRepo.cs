using SchoolWebApi.src.Dto.School;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public interface ISchoolRepo
    {
        public IQueryable<School> Get();
        public Task<School?> GetById(int id);
        public Task<School?> Create(SchoolCreateDto input);
        public Task<bool> Delete(int id);
        public Task<School?> Update(SchoolUpdateDto input, int id);
    }
}
