namespace StudentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAvatar : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "AvatarImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "AvatarImage", c => c.String());
        }
    }
}
