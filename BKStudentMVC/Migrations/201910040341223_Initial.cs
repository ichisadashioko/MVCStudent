namespace BKStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BKStudents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UndergraduateYears = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        EntryScore = c.Single(nullable: false),
                        DoB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BKStudents");
        }
    }
}
