using System;
using System.Collections.Generic;

namespace ManagementStudent.Models
{
    public partial class Point
    {
        public Guid PointId { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public double PracticePoint { get; set; }
        public double EndPoint { get; set; }
        public string Term { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifideDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
