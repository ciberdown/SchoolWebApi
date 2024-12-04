using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Dto.Teacher;
using SchoolWebApi.src.Interface.Teacher;

namespace SchoolWebApi.src.Repository.Teacher
{
    public class TeacherRepository : BaseRepo, ITeacherRepository
    {
        public TeacherRepository(SchoolDb context) : base(context) { }


        public async Task<Model.Teacher?> CreateAsync(CreateTeacherDto input)
        {
            if (input.SchoolId != null)
            {
                var foundedSchool = await _context.Schools.FindAsync(input.SchoolId);
                if (foundedSchool == null)
                    throw new KeyNotFoundException("school with this id not found!");
            }
            var teacher = new Model.Teacher(input.Name, input.SchoolId);
            var res = await _context.Teachers
                .AddAsync(teacher);
            if (res == null)
                return null;
            await _context.SaveChangesAsync();
            return await GetById(teacher.Id);


        }

        public async Task<bool> Delete(long id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return false;
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Model.Teacher>? Get()
        {
            var res = _context.Teachers
                .Include(t => t.Courses)
                .Include(t => t.School)
                .AsQueryable();
            return res;
        }

        public async Task<Model.Teacher?> GetById(long id)
        {
            var res = await _context.Teachers
                .Include(t => t.Courses)
                .Include(t => t.School)
                .FirstOrDefaultAsync(t => t.Id == id);
            return res;
        }

        public async Task<Model.Teacher?> UpdateAsync(UpdateTeacherDto input, long id)
        {
            var foundedTeacher = await _context.Teachers
                .Include(t => t.Courses)
                .Include(t => t.School)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (foundedTeacher == null)
                return null;

            if (input.SchoolId != null)
            {
                var foundedSchool = await _context.Schools.FindAsync(input.SchoolId);
                if (foundedSchool == null)
                    throw new Exception("school with this id not found!");
                foundedTeacher.SchoolId = input.SchoolId;
            }
            if (!string.IsNullOrEmpty(input.Name))
                foundedTeacher.Name = input.Name;

            foundedTeacher.LastModificationTime = input.ModificationTime;

            _context.Teachers.Update(foundedTeacher);
            await _context.SaveChangesAsync();

            return foundedTeacher;
        }
    }
}
