using Microsoft.AspNetCore.Mvc;
using WebApplication.Business;
using WebApplication.Data.Entities;

namespace WebApplication.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        public IActionResult Index(int? groupId)
        {
            if (groupId == null)
            {
                return View(_service.GetStudentsFullList());
            }

            var group = _service.GetGroup(groupId);
            
            if (group is null)
            {
                return RedirectToAction("GroupNotFound", "Groups");
            }
            ViewBag.GroupName = group.Name;
            var result = _service.GetStudentsGroupList(groupId);
            return View(result);
        }

        public IActionResult Create(int? groupId)
        {
            ViewBag.GroupsList = _service.GetGroupList(groupId);
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FirstName,LastName,GroupId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _service.Create(student);
                int? courseId = _service.GetCourseId(student.GroupId);
                if (courseId is null)
                {
                    return RedirectToAction("GroupNotFound", "Groups");
                }
                return RedirectToAction("Index", "Groups", new { courseId = courseId });
            }
            return View(student);
        }
        public IActionResult Edit(int? studentId)
        {
            var student = _service.GetStudent(studentId);
            if (student == null)
            {
                return RedirectToAction("StudentNotFound");
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (!_service.Edit(id, student))
            {
                return RedirectToAction("StudentNotFound");
            }
            return RedirectToAction("Index", new { groupId = _service.GetGroupId(id) });
        }

        public IActionResult Delete(int? studentId)
        {
            if (studentId == null)
            {
                return RedirectToAction("StudentNotFound");
            }

            var student = _service.GetStudent(studentId);
            if (student == null)
            {
                return RedirectToAction("StudentNotFound");
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var tempGroupId = _service.GetGroupId(id);

            if (!_service.Delete(id))
            {
                RedirectToAction("StudentNotFound");
            }
            return RedirectToAction("Index", new { groupId = tempGroupId });
        }

        public IActionResult RedirectToGroupsList(int? groupId)
        {
            if (groupId == null)
            {
                return RedirectToAction("Index", "Groups");
            }
            var courseId = _service.GetCourseId(groupId);
            return RedirectToAction("Index", "Groups", new { courseId = courseId });
        }

        public IActionResult StudentNotFound()
        {
            return View();
        }
    }
}
