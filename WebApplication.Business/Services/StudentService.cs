using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Business
{
    public class StudentService
    {
        private readonly WebApplicationContext _context;
        public StudentService(WebApplicationContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetGroupList(int? groupId)
        {
            var groupsList = new List<SelectListItem>();
            foreach (var item in _context.Group.ToList())
            {
                bool isSelected = groupId == item.Id;
                groupsList.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString(), Selected = isSelected });
            }
            return groupsList;
        }

        public List<Student> GetStudentsFullList() => _context.Student.ToList();

        public List<Student> GetStudentsGroupList(int? groupId) => _context.Student.Where(x => x.GroupId == groupId).ToList();

        public Group GetGroup(int? groupId) => _context.Group.FirstOrDefault(g => g.Id == groupId);

        public void Create(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
        }
       
        public Student GetStudent(int? studentId)
        {
            return _context.Student.FirstOrDefault(p => p.Id == studentId);
        }
        public bool Edit(int id, Student student)
        {
            var oldStudent = _context.Student.FirstOrDefault(s => s.Id == id);
            if (oldStudent is null)
            {
                return false;
            }
            oldStudent.FirstName = student.FirstName;
            oldStudent.LastName = student.LastName;
            _context.Student.Update(oldStudent);
            _context.SaveChanges();
            return true;
        }
        public int? GetGroupId(int studentId) => _context.Student.FirstOrDefault(s => s.Id == studentId)?.GroupId;

        public bool Delete(int studentId)
        {
            var student = _context.Student.FirstOrDefault(s => s.Id == studentId);
            if (student is null)
            {
                return false;
            }
            _context.Student.Remove(student);
            _context.SaveChanges();
            return true;
        }
        public int? GetCourseId(int? groupId) => _context.Group.FirstOrDefault(g => g.Id == groupId).CourseId;
    }
}
