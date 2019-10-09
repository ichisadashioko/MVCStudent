namespace CAStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParentInService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CAStudents", "WasParentInService", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CAStudents", "WasParentInService");
        }
    }
}
