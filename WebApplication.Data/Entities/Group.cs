using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Data.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
