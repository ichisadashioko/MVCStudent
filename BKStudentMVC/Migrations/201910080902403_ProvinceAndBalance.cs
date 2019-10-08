namespace BKStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProvinceAndBalance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BKStudents", "Province", c => c.Int(nullable: false));
            AddColumn("dbo.BKStudents", "BankBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BKStudents", "BankBalance");
            DropColumn("dbo.BKStudents", "Province");
        }
    }
}
