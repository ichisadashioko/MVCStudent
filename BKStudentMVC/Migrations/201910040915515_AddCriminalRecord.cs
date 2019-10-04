namespace BKStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCriminalRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BKStudents", "HasCriminalRecord", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BKStudents", "FirstName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BKStudents", "FirstName", c => c.String());
            DropColumn("dbo.BKStudents", "HasCriminalRecord");
        }
    }
}
