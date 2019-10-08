namespace BKStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProvinceAndBalance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BKStudents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UndergraduateYears = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        EntryScore = c.Single(nullable: false),
                        DoB = c.DateTime(nullable: false),
                        HasCriminalRecord = c.Boolean(nullable: false),
                        Province = c.Int(nullable: false),
                        BankBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BKStudents");
        }
    }
}
