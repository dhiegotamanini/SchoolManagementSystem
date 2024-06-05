                                 using Curso.Models;
using Curso.Models.Dtos;
using Curso.Repository.Interfaces;
using Curso.Services.Interfaces;

namespace Curso.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IStudentCourseRepository _repository;
        public StudentCourseService(IStudentCourseRepository repository)
        {
            _repository = repository;
        }
        public List<StudentCourseDto> GetStudentsByCourse(int courseId)
        {
            var list = _repository.GetStudentsByCourse(courseId);
            return list.Select(x => new StudentCourseDto
            {
                CourseId = x.CourseId,
                CourseName = x.Course.Name,
                Email = x.Email,
                IsActive = x.IsActive,
                StudentId = x.Id,
                StudentName = x.Name,
            }).ToList();
        }

        public List<StudentCourseDto> GetStudentsCourses()
        {
            var list = _repository.GetStudentsCourses();
            return list.Select(x => new StudentCourseDto
            {
                CourseId = x.CourseId,
                CourseName = x.Course.Name,
                Email = x.Email,
                IsActive = x.IsActive,
                StudentId = x.Id,
                StudentName = x.Name,
            }).ToList();
        }
    }
}
