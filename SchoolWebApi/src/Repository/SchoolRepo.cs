using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public class SchoolRepo : ISchoolRepo
    {
        private SchoolDb _context { get; set; }

        public SchoolRepo(SchoolDb context)
        {
            _context = context;
        }
        public IQueryable<School> Get()
        {
            var res = _context.Schools
                .Include(s => s.Students)
                .Include(s => s.Courses)
                //.ThenInclude(c => c.School)
                .AsQueryable();
            return res;
        }

        public async Task<School?> GetById(int id)
        {
            var res = await _context.Schools
                .Include(s => s.Students)
                .Include(s => s.Courses)
                //.ThenInclude(c => c.School)
                .FirstOrDefaultAsync(s => s.Id == id);
            return res;
        }
    }
}
