namespace FUStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProvinceAndBalance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FUStudents", "Province", c => c.Int(nullable: false));
            AddColumn("dbo.FUStudents", "BankBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FUStudents", "BankBalance");
            DropColumn("dbo.FUStudents", "Province");
        }
    }
}
