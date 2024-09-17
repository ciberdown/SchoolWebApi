using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Dto.Course;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public class CourseRepo : ICourseRepo
    {
        private SchoolDb _context { get; set; }

        public CourseRepo(SchoolDb context)
        {
            _context = context;
        }
        public IQueryable<Course> Get()
        {
            var res = _context.Courses
                .Include(c => c.School)
                .Include(c => c.Students)
                .AsQueryable();
            return res;
        }

        public async Task<Course?> GetById(int id)
        {
            var founded = await _context.Courses
                .Include(c => c.School)
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);
            return founded;
        }

        public async Task<Course?> Create(CourseCreateDto input)
        {
            var foundedSchool = await _context.Schools.FindAsync(input.SchoolId);
            if (foundedSchool == null)
                throw new Exception("school with this id does not exists!");
            var course = new Course(input.Name, input.Description, input.SchoolId, DateTime.Now);
            var res = await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> Delete(int id)
        {
            var founded = await _context.Courses.FindAsync(id);
            if (founded == null)
                return false;
            _context.Courses.Remove(founded);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Course?> Update(CourseUpdateDto input, int id)
        {
            var founded = await _context.Courses
                .Include(c => c.School)
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);
            if(founded == null)
                return null;
            if (string.IsNullOrWhiteSpace(input.Name))
                founded.Name = input.Name;
            if (string.IsNullOrWhiteSpace(input.Description))
                founded.Description = input.Description;
            if (input.SchoolId != null)
            {
                var foundedSchool = await _context.Schools.FindAsync(input.SchoolId);
                if (foundedSchool == null)
                    throw new Exception("school with this id does not found!");
                founded.SchoolId = (int)input.SchoolId;
            }
            founded.LastModificationTime = DateTime.Now;
            _context.Courses.Update(founded);
            await _context.SaveChangesAsync();
            return founded;
        }
    }
}
