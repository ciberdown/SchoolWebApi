using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Dto.Student;
using SchoolWebApi.src.Interface.Student;

namespace SchoolWebApi.src.Repository.Student
{
    public class StudentRepository : BaseRepo ,IStudentRepository
    {
        public StudentRepository(SchoolDb context): base(context) { }

        public async Task<Model.Student?> CreateAsync(CreateStudentDto input)
        {
            if (input.SchoolId != null)
            {
                var foundedSchool = await _context.Schools.FindAsync(input.SchoolId);
                if (foundedSchool == null)
                    throw new KeyNotFoundException("school with this id not found!");
            }
            var student = new Model.Student(input.Name, input.SchoolId);
            var res = await _context.Students
                .AddAsync(student);
            if(res == null)
                return null;
            await _context.SaveChangesAsync();
            return await GetById(student.Id);
            
            
        }

        public async Task<bool> Delete(long id)
        {
            var student = await _context.Students.FindAsync(id);
            if(student == null) return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public IQueryable<Model.Student>? Get()
        {
            var res = _context.Students
                .Include(s => s.Courses)
                .ThenInclude(c => c.Course)
                .Include(s => s.School)
                .AsQueryable();
            return res;
        }

        public async Task<Model.Student?> GetById(long id)
        {
            var res = await _context.Students
                .Include(s => s.Courses)
                .ThenInclude(c => c.Course)
                .Include(s => s.School)
                .FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        public async Task<Model.Student?> UpdateAsync(UpdateStudentDto input, long id)
        {
            var foundedStudent = await _context.Students
                .FindAsync(id);
            if(foundedStudent == null)
                return null ;

            if(input.SchoolId != null){
                var foundedSchool = await _context.Schools.FindAsync(input.SchoolId);
                if (foundedSchool == null)
                    throw new Exception("school with this id not found!");
                foundedStudent.SchoolId = input.SchoolId;
            }
            if (!string.IsNullOrEmpty(input.Name))
                foundedStudent.Name = input.Name;

            foundedStudent.LastModificationTime = input.ModificationTime;

            _context.Students.Update(foundedStudent);
            await _context.SaveChangesAsync();

            return await GetById(id);
        }
    }
}
