using Curso.Models;
using Curso.Models.Dtos;

namespace Curso.Repository.Interfaces
{
    public interface IStudentRepository
    {
        List<StudentDto> GetStudents();
        StudentDto GetStudent(int id);
        void DeleteStudent(int id);
        void UpdateStudent(int id, Student student);
        int CreateStudent(Student student);
        void CreateStudentCourse(StudentCourse studentCourse);
    }
}
