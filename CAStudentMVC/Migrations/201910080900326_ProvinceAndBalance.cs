namespace CAStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProvinceAndBalance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Province", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "BankBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "BankBalance");
            DropColumn("dbo.Students", "Province");
        }
    }
}
