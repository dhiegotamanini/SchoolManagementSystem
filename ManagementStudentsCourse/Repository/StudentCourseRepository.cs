using Curso.Data;
using Curso.Models;
using Curso.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.Repository
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly AppDbContext _context;
        public StudentCourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Student> GetStudentsByCourse(int courseId)
        {
            return _context.Students.Include(s => s.Course).Where(c => c.CourseId == courseId).ToList();
        }

        public List<Student> GetStudentsCourses()
        {
            return _context.Students.Include(s => s.Course).ToList();
        }
    }
}
