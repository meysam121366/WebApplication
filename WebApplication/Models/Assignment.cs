using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        // [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        // [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}