namespace CAStudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        EntryScore = c.Single(nullable: false),
                        DoB = c.DateTime(nullable: false),
                        HasCriminalRecord = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
