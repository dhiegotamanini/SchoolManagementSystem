using Curso.Models.Dtos;
using Curso.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        private readonly ICourseService _courseService;
        public StudentController(IStudentService service, ICourseService courseService)
        {
            _service = service;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _service.GetStudents();
            return View(students);
        }

        [HttpGet]
        public IActionResult NewStudent()
        {
            ViewBag.Courses = _courseService.GetCourses();
            return View();
        }

        [HttpGet]
        [Route("Student/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            ViewBag.OriginRequest = Request.Headers["Referer"].ToString();
            ViewBag.Courses = _courseService.GetCourses();
            var student = _service.GetStudent(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(int id, StudentDto student)
        {
            if(id == 0)
            {
                _service.CreateStudent(student);
            }
            else
            {
                _service.UpdateStudent(id, student);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Student/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var student = _service.GetStudent(id);
            return View(student);
        }

        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }

    }

}
