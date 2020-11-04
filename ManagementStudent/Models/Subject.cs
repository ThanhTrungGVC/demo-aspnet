using System;
using System.Collections.Generic;

namespace ManagementStudent.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Point = new HashSet<Point>();
        }

        public Guid SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Credit { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifideDate { get; set; }

        public virtual ICollection<Point> Point { get; set; }
    }
}
