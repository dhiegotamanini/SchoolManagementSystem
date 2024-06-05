namespace Curso.Models
{
    public class Student : Person
    {
        public DateTime DateMatricula { get; set; }
        public bool IsActive { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
