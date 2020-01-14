namespace Homework1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterBookImageCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BookImage");
        }
    }
}
