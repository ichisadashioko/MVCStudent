namespace FUStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NetFramework : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FUStudents", "HasCriminalRecord", c => c.Boolean(nullable: false));
            AlterColumn("dbo.FUStudents", "FirstName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FUStudents", "FirstName", c => c.String());
            DropColumn("dbo.FUStudents", "HasCriminalRecord");
        }
    }
}
