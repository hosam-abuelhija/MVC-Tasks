﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codeFirstTask.Models
{
    public class Teacher
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TeacherAssignment> TeacherAssignments { get; set; }
    }
}