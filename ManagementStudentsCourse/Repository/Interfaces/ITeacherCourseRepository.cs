using Curso.Models;
using Curso.Models.Dtos;

namespace Curso.Repository.Interfaces
{
    public interface ITeacherCourseRepository
    {
        List<TeacherCourse> GetTeacherCourses();
        List<TeacherCourse> GetTeacherCourse(int teacherId);
        void CreateTeacher(Teacher teacher);
        void UpdateTeacher(int id, Teacher teacher);
        void DeleteTeacher(int id);
        void ManagementTeacherCourse(TeacherCourse teacherCourse);
        void DeleteManagementTeacherCourse(List<TeacherCourse> teacherCourse);
        void ManagementTeacherCourse(List<TeacherCourse> teacherCourse);
        void CreateTeacherCourse(TeacherCourseDto teacherCourse);
        void AddCoursesByTeacher(TeacherCourseDto teacherCourse); 
        List<Teacher> GetTeachers();
        Teacher GetTeacher(int id);
        void UpdateManagementTeacherCourse(List<TeacherCourse> teacherCourse);
    }
}
