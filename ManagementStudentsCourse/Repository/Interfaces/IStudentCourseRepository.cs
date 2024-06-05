using Curso.Models;

namespace Curso.Repository.Interfaces
{
    public interface IStudentCourseRepository
    {
        List<Student> GetStudentsCourses();
        List<Student> GetStudentsByCourse(int courseId);
    }
}
