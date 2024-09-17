using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Dto.StudentCourse;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public class StudentCourseRepo : IStudentCourseRepo
    {
        private SchoolDb _context { get; set; }

        public StudentCourseRepo(SchoolDb context)
        {
            _context = context;
        }
        public async Task<List<StudentCourse>> Get()
        {
            var res = await _context
                .StudentsCourses
                .Include(sc => sc.Student)
                .ThenInclude(s => s.School)
                .Include(sc => sc.Course)
                .ToListAsync();
            return res;
        }

        public async Task<StudentCourse?> GetById(int studentId, int courseId)
        {
            var res = await _context
                .StudentsCourses
                .Include(sc => sc.Student)
                .ThenInclude(s => s.School)
                .Include(sc => sc.Course)
                .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            return res;
        }

        public async Task<bool> Delete(int studentId, int courseId)
        {
            var founded = await _context.StudentsCourses
                    .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            if(founded == null)
                return false;
            _context.StudentsCourses.Remove(founded);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StudentCourse?> Update(StudentCourseUpdateDto input, int studentId, int courseId)
        {
            await FindStudent(studentId,true);
            await FindCourse(courseId,true);

            var founded = await _context.StudentsCourses
                .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            if (founded == null)
                throw new Exception("studentCourse with this id not found!");

            if (input.StudentId != null)
            {
                await FindStudent((int)input.StudentId, true);
                founded.StudentId = (int)input.StudentId;
            }
            if(input.CourseId != null)
            {
                await FindCourse(courseId, true);
                founded.CourseId = (int)input.CourseId;
            }
            if(input.Grade != null) 
                founded.Grade = input.Grade;
            founded.LastModificationTime = DateTime.Now;

            _context.StudentsCourses.Update(founded);
            await _context.SaveChangesAsync();

            return founded;
        }

        public async Task<StudentCourse?> Create(StudentCourseCreateDto input)
        {
            await FindStudent(input.StudentId, true);
            await FindCourse(input.CourseId, true);

            var newStudent = new StudentCourse(input.StudentId, input.CourseId, input.Grade, DateTime.Now);
            await _context.StudentsCourses.AddAsync(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }

        private async Task<bool> FindStudent(int studentId, bool throwException = false)
        {
            var founded = await _context.Students.FindAsync(studentId);
            if (founded == null && throwException)
                throw new Exception("student with this id not found!");
            return founded != null;
        }
        private async Task<bool> FindCourse(int courseId, bool throwException = false)
        {
            var founded = await _context.Courses.FindAsync(courseId);
            if (founded == null && throwException)
                throw new Exception("course with this id not found!");
            return founded != null;
        }
    }
}
