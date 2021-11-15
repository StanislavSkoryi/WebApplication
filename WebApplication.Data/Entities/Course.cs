using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
