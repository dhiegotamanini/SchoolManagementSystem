using System.ComponentModel.DataAnnotations;

namespace Curso.Models.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a price")]
        [Range(0.1 , 100000)]
        public decimal? Price { get; set; }
    }
}
