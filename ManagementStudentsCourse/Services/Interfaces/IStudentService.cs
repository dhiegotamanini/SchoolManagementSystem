using Curso.Models.Dtos;

namespace Curso.Services.Interfaces
{
    public interface IStudentService
    {
        List<StudentDto> GetStudents();
        StudentDto GetStudent(int id);
        void DeleteStudent(int id);
        void UpdateStudent(int id, StudentDto student);
        void CreateStudent(StudentDto student);

    }
}
