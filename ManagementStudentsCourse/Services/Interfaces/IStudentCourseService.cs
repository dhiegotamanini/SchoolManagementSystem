using Curso.Models;
using Curso.Models.Dtos;

namespace Curso.Services.Interfaces
{
    public interface IStudentCourseService
    {
        List<StudentCourseDto> GetStudentsCourses();
        List<StudentCourseDto> GetStudentsByCourse(int courseId);
    }
}
