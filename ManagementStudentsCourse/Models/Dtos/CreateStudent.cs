using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Curso.Models.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DateMatricula { get; set; }
        public bool IsActive { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
