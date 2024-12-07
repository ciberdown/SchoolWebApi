using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Dto.Course;
using SchoolWebApi.src.Interface.Course;

namespace SchoolWebApi.src.Repository.Course
{
    public class CourseRepository : BaseRepo, ICourseRepository
    {
        public CourseRepository(SchoolDb context) : base(context) { }

        public async Task<Model.Course?> Create(CreateCourseDto input)
        {
            if(input.TeacherId != null)
            {
                var foundedTeacher = await _context.Teachers.FindAsync(input.TeacherId);
                if (foundedTeacher != null)
                    throw new Exception("teacher with this id not found");
            }
            if (input.SchoolId != null)
            {
                var foundedSchool = await _context.Schools.FindAsync(input.SchoolId);
                if (foundedSchool != null)
                    throw new Exception("school with this id not found");
            }
            Model.Course course = new Model.Course(input.Name, input.SchoolId, input.TeacherId);
            var res = await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> Delete(long id)
        {
            var res = await _context.Courses.FindAsync(id);
            if (res == null) 
                return false;
            _context.Courses.Remove(res);
            await _context.SaveChangesAsync();
            return true;

        }

        public IQueryable<Model.Course> Get()
        {
            var res = _context.Courses
                .AsQueryable();
            return res;
        }

        public async Task<Model.Course?> GetById(long id)
        {
            var res = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            return res;
        }

        public async Task<Model.Course?> Update(UpdateCourseDto input, long id)
        {
            var foundedCourse = await GetById(id);
            if (foundedCourse == null)
                return null;

            if (input.TeacherId != null)
            {
                var foundedTeacher = await _context.Teachers.FindAsync(input.TeacherId);
                if (foundedTeacher != null)
                    throw new Exception("teacher with this id not found");
                foundedCourse.TeacherId = input.TeacherId;
            }
            if (input.SchoolId != null)
            {
                var foundedSchool = await _context.Schools.FindAsync(input.SchoolId);
                if (foundedSchool != null)
                    throw new Exception("school with this id not found");
                foundedCourse.SchoolId = input.SchoolId;
            }
            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                foundedCourse.Name = input.Name;
            }
            _context.Courses.Update(foundedCourse);
            await _context.SaveChangesAsync();

            return foundedCourse;
        }
    }
}
