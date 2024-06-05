using Curso.Models.Dtos;

namespace Curso.Services.Interfaces
{
    public interface ITeacherCourseService
    {
        List<ManagementTeacherCourseDto> GetTeacherCourses();
        ManagementTeacherCourseDto GetTeacherCourse(int teacherId);
        void CreateTeacher(TeacherDto teacher);
        void UpdateTeacher(int id, TeacherDto teacherDto);
        string DeleteTeacher(int id);
        void ManagementTeacherCourse(ManagementTeacherCourseDto teacherCourseDto);
        void CreateTeacherCourse(TeacherCourseDto teacherCourse);
        List<TeacherDto> GetTeachers();
        TeacherDto GetTeacher(int id);
    }
}
