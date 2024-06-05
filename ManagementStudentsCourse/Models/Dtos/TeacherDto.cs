using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Curso.Models.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a cpf")]
        public string CPF { get; set; }

    }
}
