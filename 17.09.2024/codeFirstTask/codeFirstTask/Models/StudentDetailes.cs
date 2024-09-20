using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;

namespace codeFirstTask.Models
{
    public class StudentDetailes
    {
        [Key]
        public int StudentDetailesID { get; set; }
        public string address { get; set; }
        public int city { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}