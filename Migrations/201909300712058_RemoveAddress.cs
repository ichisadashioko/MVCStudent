namespace StudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Address", c => c.String());
        }
    }
}
