using Curso.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IStudentCourseService _service;
        public StudentCourseController(ICourseService courseService , IStudentCourseService service)
        {
            _courseService = courseService;            
            _service = service;
        }


        public IActionResult Index()
        {
            ViewBag.Courses = _courseService.GetCourses();
            var list = _service.GetStudentsCourses();
            return View(list);
        }

        [HttpPost]
        public IActionResult GetStudentsCourse(int selectedCourseId)
        {
            ViewBag.Courses = _courseService.GetCourses();
            var list = selectedCourseId != 0 ? _service.GetStudentsByCourse(selectedCourseId) : _service.GetStudentsCourses();
            ViewBag.Course = selectedCourseId;
            return View("Index" ,list);
        }
    }
}
