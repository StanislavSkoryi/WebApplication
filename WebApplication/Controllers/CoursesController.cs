using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Entities;
using WebApplication.Business;

namespace WebApplication.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseService _service;
        public CoursesController(CourseService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetCourses());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name")] Course course)
        {
            if (ModelState.IsValid)
            {
                _service.Create(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_service.IsCourseNotEmpty(id))
            {
                return RedirectToAction("CourseIsNotEmptyError");
            }

            if (!_service.Delete(id))
            {
                return RedirectToAction("CourseNotFound");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? courseId)
        {
            if (courseId == null)
            {
                return RedirectToAction("CourseNotFound");
            }

            var course = _service.GetCourse(courseId);
            if (course == null)
            {
                return RedirectToAction("CourseNotFound");
            }
            return View(course);
        }

        public IActionResult Edit(int? courseId)
        {
            var course = _service.GetCourse(courseId);
            if (course == null)
            {
                return RedirectToAction("CourseNotFound");
            }
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(int id, Course course)
        {
            if (!_service.Edit(id, course))
            {
                RedirectToAction("CourseNotFound");
            }
            return RedirectToAction("Index");
        }

        public IActionResult CourseIsNotEmptyError()
        {
            return View();
        }

        public IActionResult CourseNotFound()
        {
            return View();
        }
    }
}
