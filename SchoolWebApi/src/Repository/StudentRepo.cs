using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Dto.Student;
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

        public async Task<Student?> CreateAsync(StudentCreateDto input)
        {
            var school = await _context.Schools.FindAsync(input.SchoolId);
            if (school == null)
                throw new Exception("school with this id not found!");
            var student = new Student(input.Name, input.SchoolId, input.Description, input.Age, DateTime.Now);
            var res = await _context.Students.AddAsync(student);
            if(res == null)
                return null;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var founded = await _context.Students.FindAsync(id);
            if(founded == null)
                return false;
            _context.Students.Remove(founded);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Student?> UpdateAsync(StudentUpdateDto input, int id)
        {
            var founded = await _context.Students.FindAsync(id);
            if(founded == null)
                return null;
            if (!String.IsNullOrWhiteSpace(input.Name))
                founded.Name = input.Name;
            if (!String.IsNullOrWhiteSpace(input.Description))
                founded.Description = input.Description;
            if (input.Age != null)
                founded.Age = input.Age;
            if (input.SchoolId != null)
            {
                var school = await _context.Students.FindAsync(input.SchoolId);
                if (school == null)
                    throw new Exception("school with this id not found!");
                founded.SchoolId = (int)input.SchoolId;
            }
            founded.LastModificationTime = input.LastModificationTime;

            _context.Students.Update(founded);
            await _context.SaveChangesAsync();
            return founded;
        }
    }
}
