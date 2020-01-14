namespace Homework1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookAddImageCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookImage", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BookImage");
        }
    }
}
