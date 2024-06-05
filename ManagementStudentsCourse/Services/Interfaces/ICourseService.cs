using Curso.Models;
using Curso.Models.Dtos;

namespace Curso.Services.Interfaces
{
    public interface ICourseService
    {
        List<CourseDto> GetCourses();
        CourseDto GetCourse(int id);
        void CreateCourse(CourseDto course);
        void UpdateCourse(int id, CourseDto course);
        void DeleteCourse(int id);
    }
}
