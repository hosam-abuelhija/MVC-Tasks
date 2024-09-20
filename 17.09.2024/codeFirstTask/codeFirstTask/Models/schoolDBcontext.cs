using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;

namespace codeFirstTask.Models
{
    public class schoolDBcontext : DbContext
    {
        public schoolDBcontext() : base("SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<StudentDetailes> StudentDetailes { get; set; }
        public DbSet<TeacherAssignment> TeacherAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOptional(p => p.StudentDetailes)
                .WithRequired(a => a.Student);

            modelBuilder.Entity<TeacherAssignment>()
            .HasRequired(ta => ta.Teacher)
            .WithMany(t => t.TeacherAssignments)
            .HasForeignKey(ta => ta.TeacherID);

            modelBuilder.Entity<TeacherAssignment>()
                .HasRequired(ta => ta.Assignment)
                .WithMany(a => a.TeacherAssignments)
                .HasForeignKey(ta => ta.AssignmentID);

        }
    }
}

