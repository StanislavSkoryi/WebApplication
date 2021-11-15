using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.Data.Entities;

namespace WebApplication.Business
{
    public class CourseService
    {
        private readonly WebApplicationContext _context;

        public CourseService(WebApplicationContext context)
        {
            _context = context;
        }

        public List<Course> GetCourses() => _context.Course.ToList();

        public void Create(Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
        }

        public bool IsCourseNotEmpty(int id) => _context.Group.Any(s => s.CourseId == id);

        public bool Delete(int id)
        {
            var course = _context.Course.FirstOrDefault(m => m.Id == id);
            if (course is null)
            {
                return false;
            }
            _context.Course.Remove(course);
            _context.SaveChanges();
            return true;
        }

        public Course GetCourse(int? courseId) => _context.Course.FirstOrDefault(m => m.Id == courseId);

        public bool Edit(int id, Course course)
        {
            var oldCourse = _context.Course.FirstOrDefault(s => s.Id == id);
            if (oldCourse is null)
            {
                return false;
            }
            oldCourse.Name = course.Name;
            _context.Course.Update(oldCourse);
            _context.SaveChanges();
            return true;
        }
        public List<SelectListItem> GetCoursesList(int? courseId)
        {
            var coursesList = new List<SelectListItem>();
            foreach (var item in _context.Course.ToList())
            {
                bool isSelected = courseId == item.Id;
                coursesList.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString(), Selected = isSelected });
            }
            return coursesList;
        }
    }
}
