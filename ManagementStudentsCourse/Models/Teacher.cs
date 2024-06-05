namespace Curso.Models
{
    public class Teacher : Person
    {
        public ICollection<TeacherCourse> TeacherCourses { get; set; }

    }
}
