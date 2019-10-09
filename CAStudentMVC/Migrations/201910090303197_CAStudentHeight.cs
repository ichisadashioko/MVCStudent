namespace CAStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CAStudentHeight : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Students", newName: "CAStudents");
            AddColumn("dbo.CAStudents", "Height", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CAStudents", "Height");
            RenameTable(name: "dbo.CAStudents", newName: "Students");
        }
    }
}
