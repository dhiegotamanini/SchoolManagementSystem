namespace Curso.Models.Dtos
{
    public class TeacherCourseDto
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string NameTeacher { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string CourseName { get; set; }
        public string CourseId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
