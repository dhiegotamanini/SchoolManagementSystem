using Curso.Models;
using Curso.Models.Dtos;

namespace Curso.Repository.Interfaces
{
    public interface ICourseRepository
    {
        List<Course> GetCourses();
        Course GetCourse(int id);
        void DeleteCourse(int id);
        void UpdateCourse(Course course);
        void CreateCourse(Course course);
    }
}
