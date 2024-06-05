using System.ComponentModel.DataAnnotations;

namespace Curso.Models.Dtos
{
    public class ManagementTeacherCourseDto
    {
        public int Id { get; set; }
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }
        public Teacher Teacher { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select one teacher")]
        public int TeacherId { get; set; }
        public Course Course { get; set; }
        public List<Course> Courses { get; set; }
        public List<int> CoursesId { get; set; }
    }
}
