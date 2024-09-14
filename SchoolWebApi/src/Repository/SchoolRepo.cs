using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Dto.School;
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
                .AsQueryable();
            return res;
        }

        public async Task<School?> GetById(int id)
        {
            var res = await _context.Schools
                .Include(s => s.Students)
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == id);
            return res;
        }

        public async Task<School?> Create(SchoolCreateDto input)
        {
            var school = new School(input.Name, input.Description, DateTime.Now);
            var founded = await _context.Schools.FirstOrDefaultAsync(s => s.Name == input.Name);
            if (founded != null)
                throw new Exception("school with this name exists!");
            var res = await _context.AddAsync(school);
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _context.Schools.FindAsync(id);
            if(res == null)
                return false;
            _context.Schools.Remove(res);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<School?> Update(SchoolUpdateDto input, int id)
        {
            var founded = await _context.Schools
                .Include(s => s.Students)
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (founded == null)
                return null;

            if(!string.IsNullOrWhiteSpace(input.Name))
                founded.Name = input.Name;
            if(!string.IsNullOrWhiteSpace(input.Description))
                founded.Description = input.Description;
            founded.LastModificationTime = DateTime.Now;

            _context.Schools.Update(founded);
            await _context.SaveChangesAsync();
            return founded;
        }
    }
}
