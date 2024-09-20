using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codeFirstTask.Models
{
    public class TeacherAssignment
    {
        [Key]
        public int TeacherAssignmentID { get; set; }
        public int TeacherID { get; set; }
        public int AssignmentID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Assignments Assignment { get; set; }
    }
}