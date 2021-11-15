using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Entities;
using WebApplication.Business;

namespace WebApplication.Controllers
{
    public class GroupsController : Controller
    {
        private readonly GroupService _service;
        private readonly CourseService _serviceCourse;

        public GroupsController(GroupService service, CourseService serviceCourse)
        {
            _service = service;
            _serviceCourse = serviceCourse;
        }

        public IActionResult Index(int? courseId)
        {
            if (courseId == null)
            {
                return View(_service.GetGroupsFullList());
            }

            var course = _serviceCourse.GetCourse(courseId);

            if (course is null)
            {
                return RedirectToAction("CourseNotFound", "Courses");
            }
            ViewBag.CourseName = course.Name;
            var result = _service.GetGroupsCourseList(courseId);
            return View(result);
        }

        public IActionResult GroupIsNotEmptyError(int courseId)
        {
            return View(courseId);
        }

        public IActionResult Edit(int? groupId)
        {
            var group = _service.GetGroup(groupId);
            if (group == null)
            {
                return RedirectToAction("GroupNotFound", "Groups");
            }
            return View(group);
        }

        [HttpPost]
        public IActionResult Edit(int id, Group group)
        {
            if (!_service.Edit(id, group))
            {
                return RedirectToAction("GroupNotFound");
            }
           
            return RedirectToAction("Index", new { courseId = _service.GetCourseId(id) });
        }
         
        public IActionResult Delete(int? groupId)
        {
            if (groupId == null)
            {
                return RedirectToAction("GroupNotFound");
            }

            var group = _service.GetGroup(groupId);
            if (group == null)
            {
                return RedirectToAction("GroupNotFound", "Groups");
            }
            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            int tempCourseId = _service.GetCourseIdByGroupId(id);

            if (_service.IsGroupNotEmpty(id))
            {
                return RedirectToAction("GroupIsNotEmptyError", new { courseId = tempCourseId });
            }
            if (!_service.Delete(id))
            {
                return RedirectToAction("GroupNotFound");
            }
            return RedirectToAction("Index", new { courseId = tempCourseId });
        }


        public IActionResult Create(int? courseId)
        {
            ViewBag.CoursesList = _serviceCourse.GetCoursesList(courseId);
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, CourseId")] Group group)
        {
            if (ModelState.IsValid)
            {
                _service.Create(group);
                return RedirectToAction("Index", new { courseId = group.CourseId });
            }
            return View(group);
        }

        public IActionResult GroupNotFound()
        {
            return View();
        }
    }
}
