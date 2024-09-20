namespace codeFirstTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TeacherAssignments",
                c => new
                    {
                        TeacherAssignmentID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        AssignmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherAssignmentID)
                .ForeignKey("dbo.Assignments", t => t.AssignmentID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.AssignmentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentDetailes",
                c => new
                    {
                        StudentDetailesID = c.Int(nullable: false),
                        address = c.String(),
                        city = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentDetailesID)
                .ForeignKey("dbo.Students", t => t.StudentDetailesID)
                .Index(t => t.StudentDetailesID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetailes", "StudentDetailesID", "dbo.Students");
            DropForeignKey("dbo.TeacherAssignments", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.TeacherAssignments", "AssignmentID", "dbo.Assignments");
            DropIndex("dbo.StudentDetailes", new[] { "StudentDetailesID" });
            DropIndex("dbo.TeacherAssignments", new[] { "AssignmentID" });
            DropIndex("dbo.TeacherAssignments", new[] { "TeacherID" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentDetailes");
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherAssignments");
            DropTable("dbo.Assignments");
        }
    }
}
