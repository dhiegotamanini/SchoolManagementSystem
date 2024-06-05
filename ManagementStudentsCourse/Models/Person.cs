using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Curso.Models
{
    public class Person
    {
        public int Id { get; set; }
        [DisplayName("Full name")]
        [Required(ErrorMessage = "Field {0} is required")]
        [MaxLength(100, ErrorMessage = "Max is 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [EmailAddress(ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        public string CPF { get; set; }
    }
}
