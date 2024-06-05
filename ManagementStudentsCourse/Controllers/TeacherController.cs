using Curso.Models.Dtos;
using Curso.Services;
using Curso.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStudentsCourse.Mvc.Controllers
{

    public class TeacherController : Controller
    {
        private readonly ITeacherCourseService _service;
        public TeacherController(ITeacherCourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var teachers = _service.GetTeachers();
            return View(teachers);
        }

        [Route("Teacher/Edit/{teacherId}")]
        public IActionResult Edit(int teacherId)
        {
            ViewBag.OriginRequest = Request.Headers["Referer"].ToString();
            var teacherCourse = _service.GetTeacher(teacherId);
            return View(teacherCourse);
        }

        [HttpGet]
        public IActionResult NewTeacher()
        {
            ViewBag.OriginRequest = Request.Headers["Referer"].ToString();
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
            }

            return View("NewTeacher", teacherDto);
        }

        [HttpGet]
        [Route("Teacher/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _service.GetTeacher(id);
            return View(teacher);
        }

        [HttpPost]
        [Route("DeleteTeacherConfirmed")]
        public IActionResult DeleteTeacherConfirmed(int id)
        {
            ViewBag.ErrorMessage = _service.DeleteTeacher(id);
            if (!string.IsNullOrEmpty(ViewBag.ErrorMessage))
            {
                var teacherCourse = _service.GetTeacher(id);
                return View("Delete", teacherCourse);
            }

            return RedirectToAction("Index");
        }

    }
}
