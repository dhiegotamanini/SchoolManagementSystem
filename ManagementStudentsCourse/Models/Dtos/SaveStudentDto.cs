namespace Curso.Models.Dtos
{
    public class SaveStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DateMatricula { get; set; }
        public bool IsActive { get; set; }
        public int CourseId { get; set; }
    }
}
