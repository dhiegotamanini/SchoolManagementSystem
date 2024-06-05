using Curso.Models.Dtos;
using Curso.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Controllers
{
    public class TeacherCourseController : Controller
    {
        private readonly ITeacherCourseService _service;
        private readonly ICourseService _courseService;
        public TeacherCourseController(ITeacherCourseService service, ICourseService courseService)
        {
            _service = service;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _service.GetTeacherCourses();
            return View(list);
        }


        [HttpGet]
        public IActionResult NewTeacherCourse()
        {
            return View();
        }


        [Route("TeacherCourse/Edit/{teacherId}")]
        public IActionResult EditTeacherCourse(int teacherId)
        {
            ViewBag.Teachers = _service.GetTeachers();
            ViewBag.Courses = _courseService.GetCourses();
            var teacherCourse = _service.GetTeacherCourse(teacherId);
            return View( teacherCourse);
        }

        [HttpGet]
        public IActionResult EditManagementTeacherCourses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ManagementTeacherCourses()
        {
            ViewBag.Teachers = _service.GetTeachers();
            var courses = _courseService.GetCourses();
            ViewBag.Courses = courses;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(int id, TeacherDto teacherDto)
        {
            try
            {
                if (id == 0)
                {
                    _service.CreateTeacher(teacherDto);
                }
                else
                {
                    _service.UpdateTeacher(id, teacherDto);
                }
                ViewBag.Message = "Teacher has been save succeded";
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.HasError = true;
                ViewBag.Message = ex.Message;
                ViewBag.Teachers = _service.GetTeachers();
                ViewBag.Courses = _courseService.GetCourses();
            }

            return View("NewTeacherCourse", teacherDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ManagementTeacherCourse(int id, ManagementTeacherCourseDto teacherDto)
        {
            _service.ManagementTeacherCourse(teacherDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("TeacherCourse/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var teacherCourse = _service.GetTeacherCourse(id);
            return View(teacherCourse);
        }

        [HttpPost]
        [Route("DeleteTeacherCourseConfirmed")]
        public IActionResult DeleteTeacherCourseConfirmed(int id)
        {
            ViewBag.ErrorMessage = _service.DeleteTeacher(id);
            if (!string.IsNullOrEmpty(ViewBag.ErrorMessage))
            {
                var teacherCourse = _service.GetTeacherCourse(id);
                return View("Delete", teacherCourse);
            }

            return RedirectToAction("Index");
        }

    }
}
