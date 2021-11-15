using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.Data.Entities;

namespace WebApplication.Business
{
    public class GroupService
    {
        private readonly WebApplicationContext _context;

        public GroupService(WebApplicationContext context)
        {
            _context = context;
        }

        public List<Group> GetGroupsFullList() => _context.Group.ToList();

        public List<Group> GetGroupsCourseList(int? courseId) => _context.Group.Where(x => x.CourseId == courseId).ToList();

        public Group GetGroup(int? groupId) => _context.Group.FirstOrDefault(g => g.Id == groupId);

        public bool Edit(int? id, Group group)
        {
            var oldGroup = _context.Group.FirstOrDefault(s => s.Id == id);
            if (oldGroup is null)
            {
                return false;
            }
            oldGroup.Name = group.Name;
            _context.Group.Update(oldGroup);
            _context.SaveChanges();
            return true;
        }

        public int GetCourseIdByGroupId(int id) => _context.Group.First(g => g.Id == id).CourseId;

        public bool IsGroupNotEmpty(int id) => _context.Student.Any(s => s.GroupId == id);

        public bool Delete(int id)
        {
            var group = _context.Group.FirstOrDefault(s => s.Id == id);
            if (group is null)
            {
                return false;
            }
            _context.Group.Remove(group);
            _context.SaveChanges();
            return true;
        }

        public void Create(Group group)
        {
            _context.Add(group);
            _context.SaveChanges();
        }

        public int? GetCourseId(int groupId) => _context.Group.FirstOrDefault(g => g.Id == groupId)?.CourseId;
    }
}
