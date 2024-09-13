using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private SchoolDb _context {  get; set; }
        public StudentRepo(SchoolDb context)
        {
            _context = context;
        }
        public IQueryable<Student> GetAll()
        {
            var res = _context.Students
                .AsQueryable()
                .Include(s => s.Courses)
                .Include(s => s.School);
            return res;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var res = await _context.Students
                .Include(s => s.Courses)
                .Include(s => s.School)
                .FirstOrDefaultAsync(s => s.Id == id);
            return res;
        }
    }
}
