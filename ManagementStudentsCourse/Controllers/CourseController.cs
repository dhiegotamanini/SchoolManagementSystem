using Curso.Models.Dtos;
using Curso.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;
        public CourseController(ICourseService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var courses = _service.GetCourses();
            return View(courses);
        }

        [Route("Course/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            ViewBag.OriginRequest = Request.Headers["Referer"].ToString();
            var course = _service.GetCourse(id);
            return View(course);
        }


        [HttpGet]
        public IActionResult NewCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(int id, CourseDto courseDto)
        {

            if (id == 0)
            {
                _service.CreateCourse(courseDto);
            }
            else
            {
                _service.UpdateCourse(id, courseDto);
            }

            return RedirectToAction("Index");

        }


        [HttpGet]
        [Route("Course/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var course = _service.GetCourse(id);
            return View(course);
        }

        [HttpPost]
        [Route("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}
