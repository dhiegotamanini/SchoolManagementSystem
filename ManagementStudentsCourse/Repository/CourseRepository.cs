using Curso.Data;
using Curso.Models;
using Curso.Repository.Interfaces;

namespace Curso.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourse(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if(course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
    }
}
