using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Data
{
    public class SchoolDb : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        
        public SchoolDb(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            #region Teacher

            mb.Entity<Teacher>()
                .HasOne(t => t.School)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SchoolId);

            #endregion


            #region Course

            mb.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);
            
            mb.Entity<Course>()
                .HasOne(c => c.School)
                .WithMany(sc => sc.Courses)
                .HasForeignKey(c => c.SchoolId);

            #endregion

            #region School
            mb.Entity<School>()
                .HasIndex(s => s.Name)
                .IsUnique();

            #endregion

            #region Student
            mb.Entity<Student>()
                .HasOne(s => s.School)
                .WithMany(sc => sc.Students)
                .HasForeignKey(s => s.SchoolId);


            #endregion


            #region StudentCourse
            mb.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
            mb.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId);
            mb.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId);
            
            #endregion





            
            
        }
    }
}
