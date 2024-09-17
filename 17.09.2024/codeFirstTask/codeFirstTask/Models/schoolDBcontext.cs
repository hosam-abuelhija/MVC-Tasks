using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace codeFirstTask.Models
{
    public class schoolDBcontext : DbContext
    {
        public schoolDBcontext() : base("SchoolContext")
        {
            
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Assignments> assignments { get; set; }
    }
}