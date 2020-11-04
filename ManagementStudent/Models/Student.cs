using System;
using System.Collections.Generic;

namespace ManagementStudent.Models
{
    public partial class Student
    {
        public Student()
        {
            Point = new HashSet<Point>();
        }

        public Guid StudentId { get; set; }
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public string ClassName { get; set; }
        public string Faculty { get; set; }
        public double Gpa { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifideDate { get; set; }

        public virtual ICollection<Point> Point { get; set; }
    }
}
