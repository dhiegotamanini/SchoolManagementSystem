namespace Curso.Models.Dtos
{
    public class StudentCourseDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
