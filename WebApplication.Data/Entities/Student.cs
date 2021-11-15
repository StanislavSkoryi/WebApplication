using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
    }
}
